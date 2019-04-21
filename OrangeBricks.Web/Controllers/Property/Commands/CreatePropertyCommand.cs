using System.ComponentModel.DataAnnotations;
using OrangeBricks.Core.Infrastructure.SharedKernel;

namespace OrangeBricks.Web.Controllers.Property.Commands
{
    public class CreatePropertyCommand : BaseDomainEvent
    {
        [Required] public string PropertyType { get; set; }

        [Required] public string StreetName { get; set; }

        [Required] public string Description { get; set; }

        [Required] public int NumberOfBedrooms { get; set; }

        public string SellerUserId { get; set; }
    }
}