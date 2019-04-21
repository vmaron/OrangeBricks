using OrangeBricks.Core.Infrastructure.SharedKernel;

namespace OrangeBricks.Web.Controllers.Offers.Commands
{
    public class AcceptOfferCommand : BaseDomainEvent
    {
        public int PropertyId { get; set; }

        public int OfferId { get; set; }
    }
}