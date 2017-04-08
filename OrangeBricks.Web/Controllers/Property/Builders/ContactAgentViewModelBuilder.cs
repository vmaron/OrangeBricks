using OrangeBricks.Web.Controllers.Property.ViewModels;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Property.Builders
{
    public class ContactAgentViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public ContactAgentViewModelBuilder(IOrangeBricksContext context)
        {
            this._context = context;
        }

        public ContactAgentViewModel Build(int id)
        {
            var property = this._context.Properties.Find(id);

            return new ContactAgentViewModel
            {
                PropertyId = property.Id,
                StreetName = property.StreetName
            };
        }
    }
}