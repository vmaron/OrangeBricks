using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OrangeBricks.Core.Infrastructure.Data;
using OrangeBricks.Web.Controllers.Offers.ViewModels;
using OrangeBricks.Web.Models;
using OrangeBricks.Web.Models.Extensions;

namespace OrangeBricks.Web.Controllers.Offers.Builders
{
    public class MyOffersViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public MyOffersViewModelBuilder(IOrangeBricksContext context)
        {
            this._context = context;
        }

        public List<OffersOnPropertyViewModel> Build(string buyerId)
        {
            var offers = this._context.Properties.Where(x => x.Offers.Any(o => o.BuyerUserId == buyerId))
                .Include(x => x.Offers)
                .ToList()
                .ConvertAll(x => x.MapIt());

            return offers;
        }
    }
}