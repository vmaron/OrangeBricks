using System.Data.Entity.Migrations;

namespace OrangeBricks.Core.Migrations
{
    public partial class AddPropertyForSaleOption : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Properties", "IsListedForSale", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Properties", "IsListedForSale");
        }
    }
}
