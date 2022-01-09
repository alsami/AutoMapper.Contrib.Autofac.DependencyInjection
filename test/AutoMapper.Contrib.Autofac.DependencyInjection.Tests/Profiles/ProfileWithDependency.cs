namespace AutoMapper.Contrib.Autofac.DependencyInjection.Tests.Profiles;

// ReSharper disable once UnusedType.Global
public class ProfileWithDependency : Profile
{
    // ReSharper disable once NotAccessedField.Local
    private readonly Dependency dependency;

    public ProfileWithDependency(Dependency dependency)
    {
        this.dependency = dependency;
    }
}