using System;

namespace AutoMapper.Contrib.Autofac.DependencyInjection.TestInfrastructure.Entities
{
    public class Customer
    {
        public Guid Id { get; }

        public string Name { get; }

        public string FirstName { get; }

        public Customer(Guid id, string name, string firstName)
        {
            this.Id = id;
            this.Name = name;
            this.FirstName = firstName;
        }
    }
}