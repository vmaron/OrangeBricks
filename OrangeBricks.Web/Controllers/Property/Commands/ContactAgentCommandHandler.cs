using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Property.Commands
{
    public class ContactAgentCommandHandler
    {
        private readonly IOrangeBricksContext _context;

        public ContactAgentCommandHandler(IOrangeBricksContext context)
        {
            this._context = context;
        }

        public void Handle(ContactAgentCommand command)
        {
        }
    }
}