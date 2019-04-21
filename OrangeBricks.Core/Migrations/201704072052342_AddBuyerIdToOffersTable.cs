using System.Data.Entity.Migrations;

namespace OrangeBricks.Core.Migrations
{
    public partial class AddBuyerIdToOffersTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Offers", "BuyerUserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Offers", "BuyerUserId");
        }
    }
}
