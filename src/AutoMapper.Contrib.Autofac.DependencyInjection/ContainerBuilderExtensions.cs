using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;

namespace AutoMapper.Contrib.Autofac.DependencyInjection
{
    public static class ContainerBuilderExtensions
    {
        private const string ObsoleteMessage =
            "This extension method is obsolete. Please use the new extension 'RegisterAutoMapper' instead.";
        
        private static readonly Action<IMapperConfigurationExpression> FallBackExpression =
            config => { };

        [Obsolete(ObsoleteMessage)]
        public static ContainerBuilder AddAutoMapper(this ContainerBuilder builder, params Assembly[] assemblies)
        {
            return RegisterAddAutoMapperInternal(builder, assemblies);
        }

        [Obsolete(ObsoleteMessage)]
        public static ContainerBuilder AddAutoMapper(this ContainerBuilder builder, Assembly assembly)
        {
            return RegisterAddAutoMapperInternal(builder, new[] {assembly});
        }

        [Obsolete(ObsoleteMessage)]
        public static ContainerBuilder AddAutoMapper(this ContainerBuilder builder,
            Action<IMapperConfigurationExpression> configExpression, params Assembly[] assemblies)
        {
            return RegisterAddAutoMapperInternal(builder, assemblies, configExpression);
        }

        [Obsolete(ObsoleteMessage)]
        public static ContainerBuilder AddAutoMapper(this ContainerBuilder builder,
            Action<IMapperConfigurationExpression> configExpression, Assembly assembly)
        {
            return RegisterAddAutoMapperInternal(builder, new[] {assembly}, configExpression);
        }
        
        public static ContainerBuilder RegisterAutoMapper(this ContainerBuilder builder, params Assembly[] assemblies)
        {
            return RegisterAddAutoMapperInternal(builder, assemblies);
        }

        public static ContainerBuilder RegisterAutoMapper(this ContainerBuilder builder, Assembly assembly)
        {
            return RegisterAddAutoMapperInternal(builder, new[] {assembly});
        }

        public static ContainerBuilder RegisterAutoMapper(this ContainerBuilder builder,
            Action<IMapperConfigurationExpression> configExpression, params Assembly[] assemblies)
        {
            return RegisterAddAutoMapperInternal(builder, assemblies, configExpression);
        }

        public static ContainerBuilder RegisterAutoMapper(this ContainerBuilder builder,
            Action<IMapperConfigurationExpression> configExpression, Assembly assembly)
        {
            return RegisterAddAutoMapperInternal(builder, new[] {assembly}, configExpression);
        }

        private static ContainerBuilder RegisterAddAutoMapperInternal(ContainerBuilder builder,
            IEnumerable<Assembly> assemblies, Action<IMapperConfigurationExpression> configExpression = null)
        {
            var usedAssemblies = assemblies as Assembly[] ?? assemblies.ToArray();

            var usedConfigExpression = configExpression ?? FallBackExpression;

            builder.RegisterModule(new AutoMapperModule(usedAssemblies, usedConfigExpression));

            return builder;
        }
    }
}
