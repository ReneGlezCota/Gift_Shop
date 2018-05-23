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
                        description = c.String(),
                        imagepath = c.String(),
                        price = c.Single(nullable: false),
                        categoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Category", t => t.categoryID, cascadeDelete: true)
                .Index(t => t.categoryID);
            
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
                        roleid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Role", t => t.roleid, cascadeDelete: true)
                .Index(t => t.roleid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "roleid", "dbo.Role");
            DropForeignKey("dbo.Product", "categoryID", "dbo.Category");
            DropIndex("dbo.User", new[] { "roleid" });
            DropIndex("dbo.Product", new[] { "categoryID" });
            DropTable("dbo.User");
            DropTable("dbo.Role");
            DropTable("dbo.Product");
            DropTable("dbo.Category");
        }
    }
}
