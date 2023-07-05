namespace AutoMapper.Contrib.Autofac.DependencyInjection.SecondAssembly;

public class SecondAssemblyProfile : Profile
{
    public SecondAssemblyProfile()
    {
        this.CreateMap<ObjectSource, ObjectDestination>().ReverseMap();
    }
}