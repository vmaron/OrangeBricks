using System.Collections.Generic;
using System.Linq;
using OrangeBricks.Core.Entities.Offers;
using OrangeBricks.Web.Controllers.Offers.ViewModels;
using OrangeBricks.Web.Controllers.Property.ViewModels;

namespace OrangeBricks.Web.Controllers.Property.Extensions
{
    public static class PropertyExtensions
    {
        public static OffersOnPropertyViewModel PropertyToOffersOnPropertyViewModel(this Core.Entities.Property.Property property)
        {
            var offers = property.Offers ?? new List<Offer>();

            return new OffersOnPropertyViewModel
            {
                HasOffers = offers.Any(),
                Offers = offers.Select(x => new OfferViewModel
                {
                    Id = x.Id,
                    Amount = x.Amount,
                    CreatedAt = x.CreatedAt,
                    IsPending = x.Status == OfferStatus.Pending,
                    IsAccepted = x.Status == OfferStatus.Accepted,
                    Status = x.Status.ToString()
                }),
                PropertyId = property.Id,
                PropertyType = property.PropertyType,
                StreetName = property.StreetName,
                NumberOfBedrooms = property.NumberOfBedrooms
            };
        }

        public static PropertyViewModel PropertyToPropertyViewModel(this Core.Entities.Property.Property property)
        {
            return new PropertyViewModel
            {
                Id = property.Id,
                StreetName = property.StreetName,
                Description = property.Description,
                NumberOfBedrooms = property.NumberOfBedrooms,
                PropertyType = property.PropertyType
            };
        }
    }
}