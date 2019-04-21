using System;
using OrangeBricks.Core.Entities.Offers;
using OrangeBricks.Core.Infrastructure.Data;
using OrangeBricks.Core.Infrastructure.Interfaces;
using OrangeBricks.Web.Controllers.Offers.Commands;

namespace OrangeBricks.Web.Controllers.Offers.CommandHandlers
{
    public class AcceptOfferCommandHandler : IHandle<AcceptOfferCommand>
    {
        private readonly IOrangeBricksContext _context;

        public AcceptOfferCommandHandler(IOrangeBricksContext context)
        {
            _context = context;
        }

        public void Handle(AcceptOfferCommand command)
        {
            var offer = _context.Offers.Find(command.OfferId);

            offer.UpdatedAt = DateTime.Now;
            offer.Status = OfferStatus.Accepted;

            _context.SaveChanges();
        }
    }
}