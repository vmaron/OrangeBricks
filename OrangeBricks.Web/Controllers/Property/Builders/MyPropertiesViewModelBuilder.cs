using System.Linq;
using OrangeBricks.Core.Infrastructure.Data;
using OrangeBricks.Web.Controllers.Property.ViewModels;

namespace OrangeBricks.Web.Controllers.Property.Builders
{
    public class MyPropertiesViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public MyPropertiesViewModelBuilder(IOrangeBricksContext context)
        {
            this._context = context;
        }

        public MyPropertiesViewModel Build(string sellerId)
        {
            return new MyPropertiesViewModel
            {
                Properties = this._context.Properties
                    .Where(p => p.SellerUserId == sellerId)
                    .Select(p => new PropertyViewModel
                    {
                        Id = p.Id,
                        StreetName = p.StreetName,
                        Description = p.Description,
                        NumberOfBedrooms = p.NumberOfBedrooms,
                        PropertyType = p.PropertyType,
                        IsListedForSale = p.IsListedForSale
                    })
                    .ToList()
            };
        }
    }
}