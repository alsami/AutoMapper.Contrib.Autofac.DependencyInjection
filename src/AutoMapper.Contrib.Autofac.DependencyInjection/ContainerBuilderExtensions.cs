using System.Reflection;
using Autofac;

namespace AutoMapper.Contrib.Autofac.DependencyInjection;

public static class ContainerBuilderExtensions
{
    private const string ObsoleteMessage =
        "This extension method is obsolete. Please use the new extension 'RegisterAutoMapper' instead.";
        
    private static readonly Action<IMapperConfigurationExpression> FallBackExpression =
        config => { };
        
    public static ContainerBuilder RegisterAutoMapper(
        this ContainerBuilder builder, 
        bool propertiesAutowired = false, 
        params Assembly[] assemblies)
    {
        return RegisterAutoMapperInternal(builder, assemblies, propertiesAutowired: propertiesAutowired);
    }

    public static ContainerBuilder RegisterAutoMapper(
        this ContainerBuilder builder, 
        Assembly assembly, 
        bool propertiesAutowired = false)
    {
        return RegisterAutoMapperInternal(builder, new[] {assembly}, propertiesAutowired: propertiesAutowired);
    }

    public static ContainerBuilder RegisterAutoMapper(
        this ContainerBuilder builder, 
        Action<IMapperConfigurationExpression> configExpression, 
        bool propertiesAutowired = false, 
        params Assembly[] assemblies)
    {
        return RegisterAutoMapperInternal(builder, assemblies, configExpression, propertiesAutowired);
    }

    public static ContainerBuilder RegisterAutoMapper(
        this ContainerBuilder builder, Action<IMapperConfigurationExpression> configExpression, 
        Assembly assembly, 
        bool propertiesAutowired = false)
    {
        return RegisterAutoMapperInternal(builder, new[] {assembly}, configExpression, propertiesAutowired);
    }

    private static ContainerBuilder RegisterAutoMapperInternal(ContainerBuilder builder,
        IEnumerable<Assembly> assemblies, Action<IMapperConfigurationExpression>? configExpression = null, bool propertiesAutowired = false)
    {
        var usedAssemblies = assemblies as Assembly[] ?? assemblies.ToArray();

        var usedConfigExpression = configExpression ?? FallBackExpression;

        builder.RegisterModule(new AutoMapperModule(usedAssemblies, usedConfigExpression, propertiesAutowired));

        return builder;
    }
}