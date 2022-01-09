namespace AutoMapper.Contrib.Autofac.DependencyInjection.Tests.Profiles;

public class Dependency
{
        
}
    
public class ProfileWithDependency : Profile
{
    private readonly Dependency dependency;

    public ProfileWithDependency(Dependency dependency)
    {
        this.dependency = dependency;
    }
}