using System;
using System.Collections.Generic;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Property.Commands
{
    public class ContactAgentCommandHandler
    {
        private readonly IOrangeBricksContext _context;

        public ContactAgentCommandHandler(IOrangeBricksContext context)
        {
            this._context = context;
        }

        public void Handle(ContactAgentCommand command)
        {
            var property = this._context.Properties.Find(command.PropertyId);

            var propertyViewing = new PropertyViewing
            {
                BuyerName = command.BuyerName,
                BuyerUserId = command.BuyerUserId,
                BuyerEmail = command.Email,
                BuyerPhone = command.Phone,
                BuyerMessage = command.Message,
                Status = PropertyViewingStatus.Pending,
                //TODO: Time needs to stored in UTC format and converted to local time based on the user's time zone info
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            if (property.PropertyViewings == null)
            {
                property.PropertyViewings = new List<PropertyViewing>();
            }

            property.PropertyViewings.Add(propertyViewing);

            this._context.SaveChanges();
        }
    }
}