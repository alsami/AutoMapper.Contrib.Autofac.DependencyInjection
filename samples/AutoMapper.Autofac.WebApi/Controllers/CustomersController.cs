using System;
using System.Collections.Generic;
using AutoMapper.Autofac.Shared.Dtos;
using AutoMapper.Autofac.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapper.Autofac.WebApi.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomersController : ControllerBase
    {
        private static readonly IReadOnlyCollection<Customer> Customers = new List<Customer>
        {
            new Customer(Guid.NewGuid(), "Google"),
            new Customer(Guid.NewGuid(), "Facebook")
        };

        private readonly IMapper mapper;

        public CustomersController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<CustomerDto> Load()
        {
            return this.mapper.Map<IEnumerable<CustomerDto>>(Customers);
        }
    }
}