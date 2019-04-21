using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OrangeBricks.Core.Entities.Offers;
using OrangeBricks.Core.Infrastructure.SharedKernel;

namespace OrangeBricks.Core.Entities.Property
{
    public class Property : BaseEntity
    {
        [Required] public string PropertyType { get; set; }

        [Required] public string StreetName { get; set; }

        [Required] public string Description { get; set; }

        [Required] public int NumberOfBedrooms { get; set; }

        [Required] public string SellerUserId { get; set; }

        public bool IsListedForSale { get; set; }

        public ICollection<Offer> Offers { get; set; }

        public ICollection<PropertyViewing> PropertyViewings { get; set; }
    }
}