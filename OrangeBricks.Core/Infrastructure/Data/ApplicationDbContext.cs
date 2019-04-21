using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using OrangeBricks.Core.Entities.Offers;
using OrangeBricks.Core.Entities.Property;
using OrangeBricks.Core.Entities.Users;

namespace OrangeBricks.Core.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IOrangeBricksContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public IDbSet<Property> Properties { get; set; }
        public IDbSet<Offer> Offers { get; set; }
        public IDbSet<PropertyViewing> PropertyViewings { get; set; }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}