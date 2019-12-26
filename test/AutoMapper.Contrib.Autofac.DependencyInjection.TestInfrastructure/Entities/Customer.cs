using System;

namespace AutoMapper.Contrib.Autofac.DependencyInjection.TestInfrastructure.Entities
{
    public class Customer
    {
        public Customer(Guid id, string name, string firstName)
        {
            Id = id;
            Name = name;
            FirstName = firstName;
        }

        public Guid Id { get; }

        public string Name { get; }

        public string FirstName { get; }
    }
}