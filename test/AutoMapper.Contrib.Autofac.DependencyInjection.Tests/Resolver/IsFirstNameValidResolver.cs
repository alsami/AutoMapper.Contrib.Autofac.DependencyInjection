using AutoMapper.Contrib.Autofac.DependencyInjection.Tests.Dtos;
using AutoMapper.Contrib.Autofac.DependencyInjection.Tests.Entities;

namespace AutoMapper.Contrib.Autofac.DependencyInjection.Tests.Resolver;

public class IsFirstNameValidResolver : IValueResolver<Name, NameDto, bool>
{
    // ReSharper disable once MemberCanBePrivate.Global
    public TestConfiguration Configuration { get; set; } = null!;
        
    public bool Resolve(Name source, NameDto destination, bool destMember, ResolutionContext context)
    {
        return source.FirstName != null && source.FirstName.Length <= Configuration.FirstNameCharacterLimit;
    }
}