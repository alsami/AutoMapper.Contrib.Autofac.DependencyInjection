using AutoMapper.Contrib.Autofac.DependencyInjection.TestInfrastructure.Dtos;
using AutoMapper.Contrib.Autofac.DependencyInjection.TestInfrastructure.Entities;
using AutoMapper.Contrib.Autofac.DependencyInjection.TestInfrastructure.Resolver;

namespace AutoMapper.Contrib.Autofac.DependencyInjection.TestInfrastructure.Profiles
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