using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;

namespace AutoMapper.Contrib.Autofac.DependencyInjection
{
    public static class ContainerBuilderExtensions
    {
        private static readonly Action<IMapperConfigurationExpression> FallBackExpression =
            config => { };

        public static ContainerBuilder AddAutoMapper(this ContainerBuilder builder, params Assembly[] assemblies)
        {
            return AddAutoMapperInternal(builder, assemblies);
        }

        public static ContainerBuilder AddAutoMapper(this ContainerBuilder builder, Assembly assembly)
        {
            return AddAutoMapperInternal(builder, new[] {assembly});
        }

        public static ContainerBuilder AddAutoMapper(this ContainerBuilder builder,
            Action<IMapperConfigurationExpression> configExpression, params Assembly[] assemblies)
        {
            return AddAutoMapperInternal(builder, assemblies, configExpression);
        }

        public static ContainerBuilder AddAutoMapper(this ContainerBuilder builder,
            Action<IMapperConfigurationExpression> configExpression, Assembly assembly)
        {
            return AddAutoMapperInternal(builder, new[] {assembly}, configExpression);
        }

        private static ContainerBuilder AddAutoMapperInternal(ContainerBuilder builder,
            IEnumerable<Assembly> assemblies, Action<IMapperConfigurationExpression> configExpression = null)
        {
            var usedAssemblies = assemblies as Assembly[] ?? assemblies.ToArray();

            var usedConfigExpression = configExpression ?? FallBackExpression;

            builder.RegisterModule(new AutoMapperModule(usedAssemblies, usedConfigExpression));

            return builder;
        }
    }
}