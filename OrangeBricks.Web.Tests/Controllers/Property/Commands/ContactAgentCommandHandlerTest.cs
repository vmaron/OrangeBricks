using System.Data.Entity;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using OrangeBricks.Core.Entities;
using OrangeBricks.Core.Entities.Property;
using OrangeBricks.Core.Infrastructure.Data;
using OrangeBricks.Web.Controllers.Property.CommandHandlers;
using OrangeBricks.Web.Controllers.Property.Commands;

namespace OrangeBricks.Web.Tests.Controllers.Property.Commands
{
    [TestFixture]
    public class ContactAgentCommandHandlerTest
    {
        #region Setup/Teardown

        [SetUp]
        public void SetUp()
        {
            this._context = Substitute.For<IOrangeBricksContext>();
            this._context.PropertyViewings.Returns(Substitute.For<IDbSet<PropertyViewing>>());
            this._properties = Substitute.For<IDbSet<Core.Entities.Property.Property>>();
            this._context.Properties.Returns(this._properties);
            this._handler = new ContactAgentCommandHandler(this._context);
        }

        #endregion

        private ContactAgentCommandHandler _handler;
        private IOrangeBricksContext _context;
        private IDbSet<Core.Entities.Property.Property> _properties;

        [Test]
        public void HandleShouldAddPropertyViewing()
        {
            // Arrange
            var command = new ContactAgentCommand {PropertyId = 1};

            var property = new Core.Entities.Property.Property
            {
                Id = 1,
                Description = "Test Property"
            };

            this._properties.Find(1).Returns(property);

            // Act
            this._handler.Handle(command);

            // Assert
            this._context.Properties.Received(1).Find(1);
            this._context.Received(1).SaveChanges();
            Assert.IsTrue(property.PropertyViewings.Count == 1);
        }

        [Test]
        public void HandleShouldAddPropertyViewingForCorrectBuyer()
        {
            // Arrange
            const string buyerUserId = "12345";
            var command = new ContactAgentCommand {PropertyId = 1, BuyerUserId = buyerUserId};

            var property = new Core.Entities.Property.Property
            {
                Id = 1,
                Description = "Test Property"
            };

            this._properties.Find(1).Returns(property);

            // Act
            this._handler.Handle(command);

            // Assert
            Assert.IsTrue(property.PropertyViewings.First().BuyerUserId == buyerUserId);
        }
    }
}