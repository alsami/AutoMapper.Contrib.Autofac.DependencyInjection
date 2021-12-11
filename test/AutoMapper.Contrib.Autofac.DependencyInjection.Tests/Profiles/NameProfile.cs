using AutoMapper.Contrib.Autofac.DependencyInjection.Tests.Dtos;
using AutoMapper.Contrib.Autofac.DependencyInjection.Tests.Entities;
using AutoMapper.Contrib.Autofac.DependencyInjection.Tests.Resolver;

namespace AutoMapper.Contrib.Autofac.DependencyInjection.Tests.Profiles
{
    public class NameProfile : Profile
    {
        public NameProfile()
        {
            CreateMap<Name, NameDto>()
                .ForMember(destination => destination.IsValidFirstName, options => options.MapFrom<IsFirstNameValidResolver>());
        }
    }
}