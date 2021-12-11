using AutoMapper.Contrib.Autofac.DependencyInjection.Tests.Dtos;
using AutoMapper.Contrib.Autofac.DependencyInjection.Tests.Entities;

namespace AutoMapper.Contrib.Autofac.DependencyInjection.Tests.Resolver
{
    public class IsFirstNameValidResolver : IValueResolver<Name, NameDto, bool>
    {
        public TestConfiguration Configuration { get; set; }
        
        public bool Resolve(Name source, NameDto destination, bool destMember, ResolutionContext context)
        {
            if (source.FirstName != null && source.FirstName.Length <= Configuration.FirstNameCharacterLimit)
                return true;

            return false;
        }
    }
}