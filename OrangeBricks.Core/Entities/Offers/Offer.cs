using System;
using System.ComponentModel.DataAnnotations;

namespace OrangeBricks.Core.Entities.Offers
{
    public class Offer
    {
        [Key]
        public int Id { get; set; }

        public int Amount { get; set; }

        public OfferStatus Status { get; set; }

        public string BuyerUserId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}