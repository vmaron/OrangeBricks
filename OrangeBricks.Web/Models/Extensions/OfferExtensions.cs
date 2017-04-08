using System.Collections.Generic;
using System.Linq;
using OrangeBricks.Web.Controllers.Offers.ViewModels;

namespace OrangeBricks.Web.Models.Extensions
{
    public static class OfferExtensions
    {
        public static OffersOnPropertyViewModel MapIt(this Property property)
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
    }
}