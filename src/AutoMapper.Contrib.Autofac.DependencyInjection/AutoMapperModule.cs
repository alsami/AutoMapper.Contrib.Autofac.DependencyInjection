using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace AutoMapper.Contrib.Autofac.DependencyInjection
{
    internal class AutoMapperModule : Module
    {
        private readonly Assembly[] assembliesToScan;
        private readonly Action<IMapperConfigurationExpression> mappingConfigurationAction;

        public AutoMapperModule(Assembly[] assembliesToScan,
            Action<IMapperConfigurationExpression> mappingConfigurationAction)
        {
            this.assembliesToScan = assembliesToScan ?? throw new ArgumentNullException(nameof(assembliesToScan));
            this.mappingConfigurationAction = mappingConfigurationAction ??
                                              throw new ArgumentNullException(nameof(mappingConfigurationAction));
        }

        protected override void Load(ContainerBuilder builder)
        {
            var distinctAssemblies = this.assembliesToScan
                .Where(a => !a.IsDynamic && a.GetName().Name != nameof(AutoMapper))
                .Distinct()
                .ToArray();
            
            builder.RegisterAssemblyTypes(distinctAssemblies)
                .AssignableTo(typeof(Profile))
                .As<Profile>()
                .SingleInstance();

            builder
                .Register(componentContext => new MapperConfiguration(config => this.ConfigurationAction(config, componentContext)))
                .As<IConfigurationProvider>()
                .AsSelf()
                .SingleInstance();

            var openTypes = new[]
            {
                typeof(IValueResolver<,,>),
                typeof(IMemberValueResolver<,,,>),
                typeof(ITypeConverter<,>),
                typeof(IMappingAction<,>)
            };

            foreach (var openType in openTypes)
                builder.RegisterAssemblyTypes(distinctAssemblies)
                    .AsClosedTypesOf(openType)
                    .AsImplementedInterfaces()
                    .InstancePerDependency();

            builder
                .Register(componentContext => componentContext
                    .Resolve<MapperConfiguration>()
                    .CreateMapper(componentContext.Resolve<IComponentContext>().Resolve))
                .As<IMapper>()
                .InstancePerLifetimeScope();
        }

        private void ConfigurationAction(IMapperConfigurationExpression cfg, IComponentContext componentContext)
        {
            this.mappingConfigurationAction.Invoke(cfg);
            
            var profiles = componentContext.Resolve<IEnumerable<Profile>>();
            
            foreach (var profile in profiles.Select(profile => profile.GetType())) 
                cfg.AddProfile(profile);
        }
    }
}