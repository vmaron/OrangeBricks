using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OrangeBricks.Core.Infrastructure.Data;
using OrangeBricks.Web.Attributes;
using OrangeBricks.Web.Controllers.Property.Builders;
using OrangeBricks.Web.Controllers.Property.CommandHandlers;
using OrangeBricks.Web.Controllers.Property.Commands;
using OrangeBricks.Web.Controllers.Property.ViewModels;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Property
{
    public class PropertyController : Controller
    {
        private readonly IOrangeBricksContext _context;

        public PropertyController(IOrangeBricksContext context)
        {
            this._context = context;
        }

        [Authorize]
        public ActionResult Index(FindPropertyCommand command)
        {
            var builder = new PropertiesViewModelBuilder(this._context);
            var viewModel = builder.Build(command);

            return this.View(viewModel);
        }

        [OrangeBricksAuthorize(Roles = "Seller")]
        public ActionResult Create()
        {
            var viewModel = new CreatePropertyViewModel();

            viewModel.PossiblePropertyTypes = new[] {"House", "Flat", "Bungalow"}
                .Select(x => new SelectListItem {Value = x, Text = x})
                .AsEnumerable();

            return this.View(viewModel);
        }

        [OrangeBricksAuthorize(Roles = "Seller")]
        [HttpPost]
        public ActionResult Create(CreatePropertyCommand command)
        {
            var handler = new CreatePropertyCommandHandler(this._context);

            command.SellerUserId = this.User.Identity.GetUserId();

            handler.Handle(command);

            return this.RedirectToAction("MyProperties");
        }

        [OrangeBricksAuthorize(Roles = "Seller")]
        public ActionResult MyProperties()
        {
            var builder = new MyPropertiesViewModelBuilder(this._context);
            var viewModel = builder.Build(this.User.Identity.GetUserId());

            return this.View(viewModel);
        }

        [HttpPost]
        [OrangeBricksAuthorize(Roles = "Seller")]
        public ActionResult ListForSale(ListPropertyCommand command)
        {
            var handler = new ListPropertyCommandHandler(this._context);

            handler.Handle(command);

            return this.RedirectToAction("MyProperties");
        }

        [OrangeBricksAuthorize(Roles = "Buyer")]
        public ActionResult MakeOffer(int id)
        {
            var builder = new MakeOfferViewModelBuilder(this._context);
            var viewModel = builder.Build(id);
            return this.View(viewModel);
        }

        [HttpPost]
        [OrangeBricksAuthorize(Roles = "Buyer")]
        public ActionResult MakeOffer(MakeOfferCommand command)
        {
            var handler = new MakeOfferCommandHandler(this._context);

            command.BuyerUserId = this.User.Identity.GetUserId();
            handler.Handle(command);

            return this.RedirectToAction("Index");
        }


        [OrangeBricksAuthorize(Roles = "Buyer")]
        public ActionResult ContactAgent(int id)
        {
            var builder = new ContactAgentViewModelBuilder(this._context);
            var viewModel = builder.Build(id);
            return this.View(viewModel);
        }

        [HttpPost]
        [OrangeBricksAuthorize(Roles = "Buyer")]
        public ActionResult ContactAgent(ContactAgentCommand command)
        {
            var handler = new ContactAgentCommandHandler(this._context);

            command.BuyerUserId = this.User.Identity.GetUserId();
            handler.Handle(command);
      
            this.TempData["SuccessMessage"] = "We will contact you very shortly to schedule your booking appointment";
            return this.RedirectToAction("ContactAgent");
        }
    }
}