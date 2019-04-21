﻿using System.Data.Entity;
using NSubstitute;
using NUnit.Framework;
using OrangeBricks.Core.Infrastructure.Data;
using OrangeBricks.Web.Controllers.Property.CommandHandlers;
using OrangeBricks.Web.Controllers.Property.Commands;

namespace OrangeBricks.Web.Tests.Controllers.Property.Commands
{
    [TestFixture]
    public class ListPropertyCommandHandlerTest
    {
        private ListPropertyCommandHandler _handler;
        private IOrangeBricksContext _context;
        private IDbSet<Core.Entities.Property.Property> _properties;

        [SetUp]
        public void SetUp()
        {
            _context = Substitute.For<IOrangeBricksContext>();
            _properties = Substitute.For<IDbSet<Core.Entities.Property.Property>>();
            _context.Properties.Returns(_properties);
            _handler = new ListPropertyCommandHandler(_context);
        }

        [Test]
        public void HandleShouldUpdatePropertyToBeListedForSale()
        {
            // Arrange
            var command = new ListPropertyCommand
            {
                PropertyId = 1
            };

            var property = new Core.Entities.Property.Property
            {
                Description = "Test Property",
                IsListedForSale = false
            };

            _properties.Find(1).Returns(property);

            // Act
            _handler.Handle(command);

            // Assert
            _context.Properties.Received(1).Find(1);
            _context.Received(1).SaveChanges();
            Assert.True(property.IsListedForSale);
        }
    }
}
