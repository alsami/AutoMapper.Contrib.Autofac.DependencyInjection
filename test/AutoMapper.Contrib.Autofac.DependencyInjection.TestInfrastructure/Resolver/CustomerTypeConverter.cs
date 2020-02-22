using AutoMapper.Contrib.Autofac.DependencyInjection.TestInfrastructure.Dtos;
using AutoMapper.Contrib.Autofac.DependencyInjection.TestInfrastructure.Entities;

namespace AutoMapper.Contrib.Autofac.DependencyInjection.TestInfrastructure.Resolver
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