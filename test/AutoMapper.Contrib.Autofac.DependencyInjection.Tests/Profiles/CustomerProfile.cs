using AutoMapper.Contrib.Autofac.DependencyInjection.Tests.Converter;
using AutoMapper.Contrib.Autofac.DependencyInjection.Tests.Dtos;
using AutoMapper.Contrib.Autofac.DependencyInjection.Tests.Entities;
using AutoMapper.Contrib.Autofac.DependencyInjection.Tests.Resolver;

namespace AutoMapper.Contrib.Autofac.DependencyInjection.Tests.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            this.CreateMap<Customer, CustomerDto>()
                .ForMember(destination => destination.FullName,
                    options => options.MapFrom<CustomerFullNameResolver>())
                .ForMember(destination => destination.FullName, options => options.ConvertUsing<NoopStringValueConverter, string>(source => $"{source.FirstName} {source.Name}"))
                .ReverseMap()
                .ConvertUsing<CustomerTypeConverter>();
        }
    }
}