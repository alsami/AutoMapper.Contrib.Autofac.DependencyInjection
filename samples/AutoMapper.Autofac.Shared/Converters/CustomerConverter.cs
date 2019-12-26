using AutoMapper.Autofac.Shared.Dtos;
using AutoMapper.Autofac.Shared.Entities;

namespace AutoMapper.Autofac.Shared.Converters
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class CustomerConverter : ITypeConverter<Customer, CustomerDto>
    {
        public CustomerDto Convert(Customer source, CustomerDto destination, ResolutionContext context)
        {
            return new CustomerDto(source.Id, source.Name);
        }
    }
}