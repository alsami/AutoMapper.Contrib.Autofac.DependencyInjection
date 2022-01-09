using AutoMapper.Contrib.Autofac.DependencyInjection.Tests.Dtos;
using AutoMapper.Contrib.Autofac.DependencyInjection.Tests.Entities;

namespace AutoMapper.Contrib.Autofac.DependencyInjection.Tests.Resolver;

public class CustomerFullNameResolver : IValueResolver<Customer, CustomerDto, string>
{
    public string Resolve(Customer source, CustomerDto destination, string destMember, ResolutionContext context)
    {
        return $"{source.FirstName} {source.Name}";
    }
}