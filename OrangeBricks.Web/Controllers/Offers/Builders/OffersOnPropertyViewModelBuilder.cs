using System.Data.Entity;
using System.Linq;
using OrangeBricks.Core.Infrastructure.Data;
using OrangeBricks.Web.Controllers.Offers.ViewModels;
using OrangeBricks.Web.Models;
using OrangeBricks.Web.Models.Extensions;

namespace OrangeBricks.Web.Controllers.Offers.Builders
{
    public class OffersOnPropertyViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public OffersOnPropertyViewModelBuilder(IOrangeBricksContext context)
        {
            this._context = context;
        }

        public OffersOnPropertyViewModel Build(int id)
        {
            var property = this._context.Properties
                .Where(p => p.Id == id)
                .Include(x => x.Offers)
                .SingleOrDefault();

            return property.MapIt();
        }
    }
}