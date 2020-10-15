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
                .ReverseMap()
                .ConvertUsing<CustomerTypeConverter>();
        }
    }
}