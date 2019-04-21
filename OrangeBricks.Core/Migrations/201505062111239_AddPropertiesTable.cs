using System.Data.Entity.Migrations;

namespace OrangeBricks.Core.Migrations
{
    public partial class AddPropertiesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Properties");
        }
    }
}
