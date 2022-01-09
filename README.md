# AutoMapper.Contrib.Autofac.DependencyInjection

[![Build Application](https://github.com/alsami/AutoMapper.Contrib.Autofac.DependencyInjection/actions/workflows/push.yml/badge.svg?branch=main&event=push)](https://github.com/alsami/AutoMapper.Contrib.Autofac.DependencyInjection/actions/workflows/push.yml)
[![codecov](https://codecov.io/gh/alsami/AutoMapper.Contrib.Autofac.DependencyInjection/branch/main/graph/badge.svg)](https://codecov.io/gh/alsami/AutoMapper.Contrib.Autofac.DependencyInjection)

[![NuGet](https://img.shields.io/nuget/dt/AutoMapper.Contrib.Autofac.DependencyInjection.svg)](https://www.nuget.org/packages/AutoMapper.Contrib.Autofac.DependencyInjection) 
[![NuGet](https://img.shields.io/nuget/vpre/AutoMapper.Contrib.Autofac.DependencyInjection.svg)](https://www.nuget.org/packages/AutoMapper.Contrib.Autofac.DependencyInjection)

This is a cross platform library, written in .netstandard 2.0, that serves as an extension for [autofac's containerbuilder](https://autofac.org/).
It will register all necessary classes and interfaces of Jimmy Bogard's [AutoMapper](https://github.com/AutoMapper/AutoMapper) implementation to the autofac-container 
so you can use AutoMapper and object-mapping right ahead without worrying about setting up required infrastructure code.

## Installation

This package is available via nuget. You can install it using Visual-Studio-Nuget-Browser or by using the dotnet-cli

```
dotnet add package AutoMapper.Contrib.Autofac.DependencyInjection
```

If you want to add a specific version of this package

```
dotnet add package AutoMapper.Contrib.Autofac.DependencyInjection --version 1.0.0
```

For more information please visit the official [dotnet-cli documentation](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-add-package).

## Usage sample

After installing the package you define your entities and dtos and create profiles for them.

```csharp
public class Customer
{
	public Guid Id { get; }
	public string Name { get; }
	
	public Customer(Guid id, string name)
	{
		Id = id;
		Name = name;
	}
}

public class CustomerDto
{
	public Guid Id { get; }
	public string Name { get; }

	public CustomerDto(Guid id, string name)
	{
		Id = id;
		Name = name;
	}
}

public class CustomerProfile : Profile 
{
	public CustomerProfile()
	{
		CreateMap<Customer, CustomerDto>()
			.ConstructUsing(user => new UserDto(user.Id, user.Name))
			.ReverseMap()
			.ConstructUsing(userDto => new User(userDto.Id, userDto.Name));
	}
}

public static class Program
{
	public static void Main(string args[])
	{
		var containerBuilder = new ContainerBuilder();
		// here you have to pass in the assembly (or assemblies) containing AutoMapper types
		// stuff like profiles, resolvers and type-converters will be added by this function
		containerBuilder.RegisterAutoMapper(typeof(Program).Assembly);
		
		var container = containerBuilder.Build();

		var mapper = container.Resolve<IMapper>();

		var customer = new Customer(Guid.NewGuid(), "Google");

		var customerDto = mapper.Map<CustomerDto>(customer);
	}
}
```

### Support for Property Injection

You can set `propertiesAutowired` to true to enable property based injection, just modify the prior example like so:

```csharp
public static class Program
{
	public static void Main(string args[])
	{
		var containerBuilder = new ContainerBuilder();
		
		// Update this line with the setting:
		containerBuilder.RegisterAutoMapper(typeof(Program).Assembly, propertiesAutowired: true);
		
		var container = containerBuilder.Build();

		var mapper = container.Resolve<IMapper>();

		var customer = new Customer(Guid.NewGuid(), "Google");

		var customerDto = mapper.Map<CustomerDto>(customer);
	}
}
```

### Validating your configuration

`AutoMapper` allows the user to validate their mappings. **This should only be done within a test project, since it's time-consuming**

```csharp
var containerBuilder = new ContainerBuilder();
containerBuilder.RegisterAutoMapper(typeof(Program).Assembly);

var container = containerBuilder.Build();
var mapperConfiguration = container.Resolve<MapperConfiguration>();

// this line will throw when mappings are not working as expected
// it's wise to write a test for that, which is always executed within a CI pipeline for your project.
mapperConfiguration.AssertConfigurationIsValid();
```
