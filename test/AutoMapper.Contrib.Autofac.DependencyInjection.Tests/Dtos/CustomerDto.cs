using System;

namespace AutoMapper.Contrib.Autofac.DependencyInjection.Tests.Dtos;

public class CustomerDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string FullName { get; set; } = null!;
}