using System;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using OrangeBricks.Core.Entities.Offers;
using OrangeBricks.Core.Entities.Property;
using OrangeBricks.Core.Entities.Users;

namespace OrangeBricks.Core.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IOrangeBricksContext
    {
        private static readonly Lazy<ApplicationDbContext> _instance =
            new Lazy<ApplicationDbContext>(() => new ApplicationDbContext());


        public ApplicationDbContext()
            : base("DefaultConnection", false)
        {
        }

        public static ApplicationDbContext Instance => _instance.Value;

        public IDbSet<Property> Properties { get; set; }
        public IDbSet<Offer> Offers { get; set; }
        public IDbSet<PropertyViewing> PropertyViewings { get; set; }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public static ApplicationDbContext Create()
        {
            return Instance;
        }
    }
}