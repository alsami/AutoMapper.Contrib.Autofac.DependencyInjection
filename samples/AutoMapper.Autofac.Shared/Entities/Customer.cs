using System;

namespace AutoMapper.Autofac.Shared.Entities
{
    public class Customer
    {
        public Customer(Guid id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public Guid Id { get; }
        public string Name { get; }
    }
}