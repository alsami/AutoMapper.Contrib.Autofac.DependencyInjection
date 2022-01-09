using System;

namespace AutoMapper.Contrib.Autofac.DependencyInjection.Tests.Entities;

public class Customer
{
    public Customer(Guid id, string name, string firstName)
    {
        this.Id = id;
        this.Name = name;
        this.FirstName = firstName;
    }

    public Guid Id { get; }

    public string Name { get; }

    public string FirstName { get; }
}