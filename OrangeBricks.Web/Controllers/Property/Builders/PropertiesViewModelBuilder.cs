using System.Linq;
using OrangeBricks.Core.Infrastructure.Data;
using OrangeBricks.Web.Controllers.Property.Commands;
using OrangeBricks.Web.Controllers.Property.ViewModels;
using OrangeBricks.Web.Models.Extensions;

namespace OrangeBricks.Web.Controllers.Property.Builders
{
    public class PropertiesViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public PropertiesViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public PropertiesViewModel Build(FindPropertyCommand command)
        {
            var properties = _context.Properties
                .Where(p => p.IsListedForSale);

            if (!string.IsNullOrWhiteSpace(command.Search))
            {
                properties = properties.Where(x => x.StreetName.Contains(command.Search)
                                                   || x.Description.Contains(command.Search));
            }

            return new PropertiesViewModel
            {
                Properties = properties
                    .ToList()
                    .Select(x => x.PropertyToPropertyViewModel())
                    .ToList(),
                Search = command.Search
            };
        }
    }
}