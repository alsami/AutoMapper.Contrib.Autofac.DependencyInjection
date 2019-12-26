using System;
using System.Collections.Generic;
using Autofac;
using AutoMapper.Autofac.Shared.Dtos;
using AutoMapper.Autofac.Shared.Entities;
using AutoMapper.Contrib.Autofac.DependencyInjection;

namespace AutoMapper.Autofac.ConsoleApp
{
    internal class Program
    {
        private static readonly IReadOnlyCollection<Customer> Customers = new List<Customer>
        {
            new Customer(Guid.NewGuid(), "Google"),
            new Customer(Guid.NewGuid(), "Facebook")
        };
        
        private static void Main(string[] args)
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.AddAutoMapper(typeof(Customer).Assembly);

            var container = containerBuilder.Build();

            var mapper = container.Resolve<IMapper>();

            var customerDtos = mapper.Map<IEnumerable<CustomerDto>>(Customers);

            foreach (var customer in customerDtos)
                Console.WriteLine(customer);
        }
    }
}