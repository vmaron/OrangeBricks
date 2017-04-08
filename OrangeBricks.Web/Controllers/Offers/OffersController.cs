using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OrangeBricks.Web.Attributes;
using OrangeBricks.Web.Controllers.Offers.Builders;
using OrangeBricks.Web.Controllers.Offers.Commands;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Offers
{
    public class OffersController : Controller
    {
        private readonly IOrangeBricksContext _context;

        public OffersController(IOrangeBricksContext context)
        {
            this._context = context;
        }

        [OrangeBricksAuthorize(Roles = "Seller")]
        public ActionResult OnProperty(int id)
        {
            var builder = new OffersOnPropertyViewModelBuilder(this._context);
            var viewModel = builder.Build(id);

            return this.View(viewModel);
        }

        [OrangeBricksAuthorize(Roles = "Seller")]
        [HttpPost]
        public ActionResult Accept(AcceptOfferCommand command)
        {
            var handler = new AcceptOfferCommandHandler(this._context);

            handler.Handle(command);

            return this.RedirectToAction("OnProperty", new {id = command.PropertyId});
        }

        [OrangeBricksAuthorize(Roles = "Seller")]
        [HttpPost]
        public ActionResult Reject(RejectOfferCommand command)
        {
            var handler = new RejectOfferCommandHandler(this._context);

            handler.Handle(command);

            return this.RedirectToAction("OnProperty", new {id = command.PropertyId});
        }

        [OrangeBricksAuthorize(Roles = "Buyer")]
        public ActionResult MyOffers()
        {
            var builder = new MyOffersViewModelBuilder(this._context);
            var viewModel = builder.Build(this.User.Identity.GetUserId());

            return this.View(viewModel);
        }
    }
}