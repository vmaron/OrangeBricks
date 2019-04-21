using OrangeBricks.Core.Infrastructure.Data;
using OrangeBricks.Web.Controllers.Property.ViewModels;

namespace OrangeBricks.Web.Controllers.Property.Builders
{
    public class ContactAgentViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public ContactAgentViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public ContactAgentViewModel Build(int id)
        {
            var property = _context.Properties.Find(id);

            return new ContactAgentViewModel
            {
                PropertyId = property.Id,
                StreetName = property.StreetName
            };
        }
    }
}