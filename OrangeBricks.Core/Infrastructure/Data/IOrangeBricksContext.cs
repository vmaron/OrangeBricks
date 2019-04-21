using System.Data.Entity;
using OrangeBricks.Core.Entities;
using OrangeBricks.Core.Entities.Offers;
using OrangeBricks.Core.Entities.Property;

namespace OrangeBricks.Core.Infrastructure.Data
{
    public interface IOrangeBricksContext
    {
        IDbSet<Property> Properties { get; set; }
        IDbSet<Offer> Offers { get; set; }
        IDbSet<PropertyViewing> PropertyViewings { get; set; }

        void SaveChanges();
    }
}