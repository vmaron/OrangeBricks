using OrangeBricks.Core.Infrastructure.SharedKernel;

namespace OrangeBricks.Web.Controllers.Property.Commands
{
    public class MakeOfferCommand : BaseDomainEvent
    {
        public int PropertyId { get; set; }

        public int Offer { get; set; }

        public string BuyerUserId { get; set; }
    }
}