using System;
using AutoMapper.Configuration.Annotations;
using AutoMapper.Contrib.Autofac.DependencyInjection.TestInfrastructure.Entities;
using AutoMapper.Contrib.Autofac.DependencyInjection.TestInfrastructure.Resolver;

namespace AutoMapper.Contrib.Autofac.DependencyInjection.TestInfrastructure.Dtos
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