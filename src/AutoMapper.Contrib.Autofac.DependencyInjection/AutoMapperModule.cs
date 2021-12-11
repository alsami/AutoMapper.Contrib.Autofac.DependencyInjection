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
        private readonly bool propertiesAutowired;

        public AutoMapperModule(Assembly[] assembliesToScan,
            Action<IMapperConfigurationExpression> mappingConfigurationAction,
            bool propertiesAutowired)
        {
            this.assembliesToScan = assembliesToScan ?? throw new ArgumentNullException(nameof(assembliesToScan));
            this.mappingConfigurationAction = mappingConfigurationAction ??
                                              throw new ArgumentNullException(nameof(mappingConfigurationAction));
            this.propertiesAutowired = propertiesAutowired;
        }

        protected override void Load(ContainerBuilder builder)
        {
            var distinctAssemblies = this.assembliesToScan
                .Where(a => !a.IsDynamic && a.GetName().Name != nameof(AutoMapper))
                .Distinct()
                .ToArray();
            
            var profiles = builder.RegisterAssemblyTypes(distinctAssemblies)
                .AssignableTo(typeof(Profile))
                .As<Profile>()
                .SingleInstance();

            if (propertiesAutowired)
                profiles.PropertiesAutowired();

            builder
                .Register(componentContext => new MapperConfiguration(config => this.ConfigurationAction(config, componentContext)))
                .As<IConfigurationProvider>()
                .AsSelf()
                .SingleInstance();

            var openTypes = new[]
            {
                typeof(IValueResolver<,,>),
                typeof(IValueConverter<,>),
                typeof(IMemberValueResolver<,,,>),
                typeof(ITypeConverter<,>),
                typeof(IMappingAction<,>)
            };

            foreach (var openType in openTypes)
            {
                var openTypeBuilder = builder.RegisterAssemblyTypes(distinctAssemblies)
                    .AsClosedTypesOf(openType)
                    .AsImplementedInterfaces()
                    .InstancePerDependency();

                if (propertiesAutowired)
                    openTypeBuilder.PropertiesAutowired();
            }

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
            
            foreach (var profile in profiles) 
                cfg.AddProfile(profile);
        }
    }
}