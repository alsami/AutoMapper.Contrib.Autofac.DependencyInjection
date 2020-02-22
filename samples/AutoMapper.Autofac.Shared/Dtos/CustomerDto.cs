using System;

namespace AutoMapper.Autofac.Shared.Dtos
{
    public class CustomerDto
    {
        public CustomerDto(Guid id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public Guid Id { get; }
        public string Name { get; }

        public override string ToString()
        {
            return $"{this.Id} - {this.Name}";
        }
    }
}