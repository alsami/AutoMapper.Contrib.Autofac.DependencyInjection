using System;
using AutoMapper.Configuration.Annotations;
using AutoMapper.Contrib.Autofac.DependencyInjection.Tests.Entities;
using AutoMapper.Contrib.Autofac.DependencyInjection.Tests.Resolver;

namespace AutoMapper.Contrib.Autofac.DependencyInjection.Tests.Dtos
{
    [AutoMap(typeof(Customer))]
    public class CustomerAttributeDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string FirstName { get; set; }

        [ValueResolver(typeof(CustomerFullNameResolver))]
        public string FullName { get; set; }
    }
}