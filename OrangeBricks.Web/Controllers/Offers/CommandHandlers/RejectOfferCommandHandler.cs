using System;
using OrangeBricks.Core.Entities;
using OrangeBricks.Core.Entities.Offers;
using OrangeBricks.Core.Infrastructure.Data;
using OrangeBricks.Web.Controllers.Offers.Commands;

namespace OrangeBricks.Web.Controllers.Offers.CommandHandlers
{
    public class RejectOfferCommandHandler
    {
        private readonly IOrangeBricksContext _context;

        public RejectOfferCommandHandler(IOrangeBricksContext context)
        {
            _context = context;
        }

        public void Handle(RejectOfferCommand command)
        {
            var offer = _context.Offers.Find(command.OfferId);

            offer.UpdatedAt = DateTime.Now;
            offer.Status = OfferStatus.Rejected;

            _context.SaveChanges();
        }
    }
}