using System;
using OrangeBricks.Core.Infrastructure.SharedKernel;

namespace OrangeBricks.Core.Entities.Offers
{
    public class Offer : BaseEntity
    {
        public int Amount { get; set; }

        public OfferStatus Status { get; set; }

        public string BuyerUserId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}