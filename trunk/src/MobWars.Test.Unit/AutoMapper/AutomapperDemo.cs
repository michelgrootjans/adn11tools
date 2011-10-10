using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using NUnit.Framework;

namespace MobWars.Test.Unit.AutoMapper
{
    [TestFixture]
    public class AutomapperDemo
    {
        [Test]
        public void should_map_customer()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Order, OrderDto>();

            var customer = new Customer("agileminds");
            customer.Order(2, new Product("planning poker cards", 0.95));

            var customerDto = Mapper.Map<Customer, CustomerDto>(customer);
            Assert.That(customerDto.Name, Is.EqualTo("agileminds"));
            Assert.That(customerDto.OrdersCount, Is.EqualTo(1));
        }
    }

    public class CustomerDto
    {
        public string Name { get; set; }
        public int OrdersCount { get; set; }
    }

    public class OrderDto
    {
    }
}