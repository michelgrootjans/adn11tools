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
            var customer = new Customer("agileminds");
        }
    }
}