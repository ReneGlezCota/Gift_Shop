namespace Gift_Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        category = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        price = c.Single(nullable: false),
                        categoryid_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Category", t => t.categoryid_id)
                .Index(t => t.categoryid_id);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        role = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        username = c.String(),
                        password = c.String(),
                        firstname = c.String(),
                        lastname = c.String(),
                        roleid_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Role", t => t.roleid_id)
                .Index(t => t.roleid_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "roleid_id", "dbo.Role");
            DropForeignKey("dbo.Product", "categoryid_id", "dbo.Category");
            DropIndex("dbo.User", new[] { "roleid_id" });
            DropIndex("dbo.Product", new[] { "categoryid_id" });
            DropTable("dbo.User");
            DropTable("dbo.Role");
            DropTable("dbo.Product");
            DropTable("dbo.Category");
        }
    }
}
