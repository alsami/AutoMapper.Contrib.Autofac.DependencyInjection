using AutoMapper.Autofac.Shared.Converters;
using AutoMapper.Autofac.Shared.Dtos;
using AutoMapper.Autofac.Shared.Entities;

namespace AutoMapper.Autofac.Shared.Profiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        this.CreateMap<Customer, CustomerDto>()
            .ConvertUsing<CustomerConverter>();
    }
}