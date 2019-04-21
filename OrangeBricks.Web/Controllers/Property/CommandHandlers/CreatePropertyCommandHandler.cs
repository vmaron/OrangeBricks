using OrangeBricks.Core.Infrastructure.Data;
using OrangeBricks.Web.Controllers.Property.Commands;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Property.CommandHandlers
{
    public class CreatePropertyCommandHandler
    {
        private readonly IOrangeBricksContext _context;

        public CreatePropertyCommandHandler(IOrangeBricksContext context)
        {
            this._context = context;
        }

        public void Handle(CreatePropertyCommand command)
        {
            var property = new Core.Entities.Property.Property
            {
                PropertyType = command.PropertyType,
                StreetName = command.StreetName,
                Description = command.Description,
                NumberOfBedrooms = command.NumberOfBedrooms
            };

            property.SellerUserId = command.SellerUserId;

            this._context.Properties.Add(property);

            this._context.SaveChanges();
        }
    }
}