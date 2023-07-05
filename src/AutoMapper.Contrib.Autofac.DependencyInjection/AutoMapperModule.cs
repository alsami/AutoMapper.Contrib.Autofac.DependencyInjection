using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace AutoMapper.Contrib.Autofac.DependencyInjection;

internal class AutoMapperModule : Module
{
    private readonly Assembly[] assembliesToScan;
    private readonly Action<IMapperConfigurationExpression> mappingConfigurationAction;
    private readonly bool propertiesAutowired;

    private static readonly MapperConfigurationExpression MapperConfigurationExpression = new();

    public AutoMapperModule(
        Assembly[] assembliesToScan,
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
            
        var profiles = builder
            .RegisterAssemblyTypes(distinctAssemblies)
            .AssignableTo(typeof(Profile))
            .As<Profile>()
            .SingleInstance();

        if (propertiesAutowired)
        {
            profiles.PropertiesAutowired();
        }

        builder
            .RegisterType<MapperConfigurationExpression>()
            .AsSelf()
            .IfNotRegistered(typeof(MapperConfigurationExpression))
            .SingleInstance();

        builder
            .Register(componentContext => new MapperConfiguration(componentContext.Resolve<MapperConfigurationExpression>()))
            .AsSelf()
            .As<IConfigurationProvider>()
            .IfNotRegistered(typeof(MapperConfigurationExpression))
            .SingleInstance();

        builder
            .Register(componentContext =>
            {
                var expression = componentContext.Resolve<MapperConfigurationExpression>();
                this.ConfigurationAction(expression, componentContext);
                return new MapperConfigurationExpressionAdapter(expression);
            })
            .AsSelf()
            .InstancePerDependency();


        builder
            .Register(componentContext =>
            {
                var adapter = componentContext.Resolve<MapperConfigurationExpressionAdapter>();

                return new MapperConfiguration(adapter.MapperConfigurationExpression);
            })
            .As<IConfigurationProvider>()
            .AsSelf()
            .IfNotRegistered(typeof(IConfigurationProvider))
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
            {
                openTypeBuilder.PropertiesAutowired();
            }
        }

        builder
            .Register(componentContext => componentContext
                .Resolve<MapperConfiguration>()
                .CreateMapper(componentContext.Resolve<IComponentContext>().Resolve))
            .As<IMapper>()
            .IfNotRegistered(typeof(IMapper))
            .InstancePerLifetimeScope();
    }

    private void ConfigurationAction(IMapperConfigurationExpression cfg, IComponentContext componentContext)
    {
        this.mappingConfigurationAction.Invoke(cfg);
            
        var profiles = componentContext.Resolve<IEnumerable<Profile>>();

        foreach (var profile in profiles)
        {
            cfg.AddProfile(profile);
        }
    }
}