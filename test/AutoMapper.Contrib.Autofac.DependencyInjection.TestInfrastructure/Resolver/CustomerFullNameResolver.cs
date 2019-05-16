using AutoMapper.Contrib.Autofac.DependencyInjection.TestInfrastructure.Dtos;
using AutoMapper.Contrib.Autofac.DependencyInjection.TestInfrastructure.Entities;

namespace AutoMapper.Contrib.Autofac.DependencyInjection.TestInfrastructure.Resolver
{
    public class CustomerFullNameResolver : IValueResolver<Customer, CustomerDto, string>
    {
        public string Resolve(Customer source, CustomerDto destination, string destMember, ResolutionContext context)
        {
            return $"{source.FirstName} {source.Name}";
        }
    }
}