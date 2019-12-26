using System;

namespace AutoMapper.Autofac.Shared.Entities
{
    public class Customer
    {
        public Customer(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; }
        public string Name { get; }
    }
}