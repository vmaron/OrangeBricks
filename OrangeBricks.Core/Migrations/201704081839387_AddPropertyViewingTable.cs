using System.Data.Entity.Migrations;

namespace OrangeBricks.Core.Migrations
{
    public partial class AddPropertyViewingTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PropertyViewings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BuyerUserId = c.String(nullable: false, maxLength: 36),
                        BuyerName = c.String(nullable: false, maxLength: 64),
                        BuyerPhone = c.String(nullable: false, maxLength: 16),
                        BuyerEmail = c.String(nullable: false, maxLength: 64),
                        BuyerMessage = c.String(),
                        SellerNotes = c.String(),
                        Status = c.Int(nullable: false),
                        AppointmentDate = c.DateTime(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        PropertyId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Properties", t => t.PropertyId)
                .Index(t => t.BuyerUserId)
                .Index(t => t.PropertyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PropertyViewings", "PropertyId", "dbo.Properties");
            DropIndex("dbo.PropertyViewings", new[] { "PropertyId" });
            DropIndex("dbo.PropertyViewings", new[] { "BuyerUserId" });
            DropTable("dbo.PropertyViewings");
        }
    }
}
