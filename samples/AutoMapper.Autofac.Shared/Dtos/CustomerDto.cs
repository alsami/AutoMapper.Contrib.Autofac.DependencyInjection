using System;

namespace AutoMapper.Autofac.Shared.Dtos
{
    public class CustomerDto
    {
        public CustomerDto(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; }
        public string Name { get; }

        public override string ToString()
        {
            return $"{Id} - {Name}";
        }
    }
}