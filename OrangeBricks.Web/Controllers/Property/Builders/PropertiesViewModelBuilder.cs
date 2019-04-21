using System.Linq;
using OrangeBricks.Core.Infrastructure.Data;
using OrangeBricks.Web.Controllers.Property.Extensions;
using OrangeBricks.Web.Controllers.Property.ViewModels;

namespace OrangeBricks.Web.Controllers.Property.Builders
{
    public class PropertiesViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public PropertiesViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public PropertiesViewModel Build(string query)
        {
            var properties = _context.Properties
                .Where(p => p.IsListedForSale);

            if (!string.IsNullOrWhiteSpace(query))
            {
                properties = properties.Where(x => x.StreetName.Contains(query)
                                                   || x.Description.Contains(query));
            }

            return new PropertiesViewModel
            {
                Properties = properties
                    .ToList()
                    .Select(x => x.PropertyToPropertyViewModel())
                    .ToList(),
                Search = query
            };
        }
    }
}