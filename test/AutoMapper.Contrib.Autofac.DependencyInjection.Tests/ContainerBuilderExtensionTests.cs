using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using AutoMapper.Contrib.Autofac.DependencyInjection.Tests.Dtos;
using AutoMapper.Contrib.Autofac.DependencyInjection.Tests.Entities;
using AutoMapper.Contrib.Autofac.DependencyInjection.Tests.Profiles;
using Xunit;

namespace AutoMapper.Contrib.Autofac.DependencyInjection.Tests
{
    public class ContainerBuilderExtensionTests
    {
        [Fact]
        public void
            ContainerBuilderExtensions_AddAutoMapper_Convert_Customer_To_CustomerAttributeDto_Expect_Values_To_Be_Equal()
        {
            var customer = new Customer(Guid.NewGuid(), "google", "google1");

            var builder = new ContainerBuilder()
                .RegisterAutoMapper(typeof(Customer).Assembly);

            builder.RegisterType<Dependency>()
                .AsSelf();

            var container = builder.Build();

            var mapper = container.Resolve<IMapper>();

            var customerDto = mapper.Map<CustomerDto>(customer);
            var reverseMappedCustomer = mapper.Map<Customer>(customerDto);

            Assert.Equal(customer.Id, reverseMappedCustomer.Id);
            Assert.Equal(customer.FirstName, reverseMappedCustomer.FirstName);
            Assert.Equal(customer.Name, reverseMappedCustomer.Name);
            
            Assert.Equal(customer.Id, customerDto.Id);
            Assert.Equal(customer.FirstName, customerDto.FirstName);
            Assert.Equal(customer.Name, customerDto.Name);
            Assert.Equal($"{customer.FirstName} {customer.Name}", customerDto.FullName);
        }

        [Fact]
        public void ContainerBuilderExtensions_AddAutoMapperAssembliesOnly_ExpectTypesToBeRegistered()
        {
            var builder = new ContainerBuilder()
                .RegisterAutoMapper(typeof(Customer).Assembly);

            builder.RegisterType<Dependency>()
                .AsSelf();

            var container = builder.Build();

            Assert.True(container.IsRegistered<IEnumerable<Profile>>());
            Assert.True(container.IsRegistered<MapperConfiguration>());
            Assert.True(container.IsRegistered<IConfigurationProvider>());
            Assert.True(container.IsRegistered<IMapper>());
            Assert.True(container.IsRegistered<IValueResolver<Customer, CustomerDto, string>>());
            Assert.True(container.IsRegistered<IValueConverter<string, string>>());
            Assert.True(container.IsRegistered<ITypeConverter<CustomerDto, Customer>>());

            var profiles = container.Resolve<IEnumerable<Profile>>();
            var resolver = container.Resolve<IValueResolver<Customer, CustomerDto, string>>();
            var converter = container.Resolve<IValueConverter<string, string>>();
            var mapper = container.Resolve<IMapper>();

            Assert.Equal(2, profiles.Count());
            Assert.NotNull(resolver);
            Assert.NotNull(converter);
            Assert.NotNull(mapper);
        }
    }
}