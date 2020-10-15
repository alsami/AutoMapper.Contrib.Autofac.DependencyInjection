using AutoMapper.Contrib.Autofac.DependencyInjection.Tests.Dtos;
using AutoMapper.Contrib.Autofac.DependencyInjection.Tests.Entities;

namespace AutoMapper.Contrib.Autofac.DependencyInjection.Tests.Resolver
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class CustomerTypeConverter : ITypeConverter<CustomerDto, Customer>
    {
        public Customer Convert(CustomerDto source, Customer destination, ResolutionContext context)
        {
            return new Customer(source.Id, source.Name, source.FirstName);
        }
    }
}