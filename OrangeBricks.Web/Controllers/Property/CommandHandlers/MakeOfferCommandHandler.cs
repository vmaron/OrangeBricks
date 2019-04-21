using System;
using System.Collections.Generic;
using OrangeBricks.Core.Entities.Offers;
using OrangeBricks.Core.Infrastructure.Data;
using OrangeBricks.Core.Infrastructure.Interfaces;
using OrangeBricks.Web.Controllers.Property.Commands;

namespace OrangeBricks.Web.Controllers.Property.CommandHandlers
{
    public class MakeOfferCommandHandler : IHandle<MakeOfferCommand>
    {
        private readonly IOrangeBricksContext _context;

        public MakeOfferCommandHandler(IOrangeBricksContext context)
        {
            _context = context;
        }

        public void Handle(MakeOfferCommand command)
        {
            var property = _context.Properties.Find(command.PropertyId);

            var offer = new Offer
            {
                Amount = command.Offer,
                Status = OfferStatus.Pending,
                BuyerUserId = command.BuyerUserId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            if (property.Offers == null)
            {
                property.Offers = new List<Offer>();
            }
                
            property.Offers.Add(offer);
            
            _context.SaveChanges();
        }
    }
}