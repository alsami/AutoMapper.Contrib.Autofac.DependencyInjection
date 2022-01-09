
namespace AutoMapper.Contrib.Autofac.DependencyInjection.Tests.Dtos;

public class NameDto
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public bool IsValidFirstName { get; set; }
}