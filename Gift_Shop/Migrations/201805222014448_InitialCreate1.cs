namespace Gift_Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "categoryid_id", "dbo.Category");
            DropForeignKey("dbo.User", "roleid_id", "dbo.Role");
            DropIndex("dbo.Product", new[] { "categoryid_id" });
            DropIndex("dbo.User", new[] { "roleid_id" });
            RenameColumn(table: "dbo.Product", name: "categoryid_id", newName: "categoryID");
            RenameColumn(table: "dbo.User", name: "roleid_id", newName: "roleid");
            AlterColumn("dbo.Product", "categoryID", c => c.Int(nullable: false));
            AlterColumn("dbo.User", "roleid", c => c.Int(nullable: false));
            CreateIndex("dbo.Product", "categoryID");
            CreateIndex("dbo.User", "roleid");
            AddForeignKey("dbo.Product", "categoryID", "dbo.Category", "id", cascadeDelete: true);
            AddForeignKey("dbo.User", "roleid", "dbo.Role", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "roleid", "dbo.Role");
            DropForeignKey("dbo.Product", "categoryID", "dbo.Category");
            DropIndex("dbo.User", new[] { "roleid" });
            DropIndex("dbo.Product", new[] { "categoryID" });
            AlterColumn("dbo.User", "roleid", c => c.Int());
            AlterColumn("dbo.Product", "categoryID", c => c.Int());
            RenameColumn(table: "dbo.User", name: "roleid", newName: "roleid_id");
            RenameColumn(table: "dbo.Product", name: "categoryID", newName: "categoryid_id");
            CreateIndex("dbo.User", "roleid_id");
            CreateIndex("dbo.Product", "categoryid_id");
            AddForeignKey("dbo.User", "roleid_id", "dbo.Role", "id");
            AddForeignKey("dbo.Product", "categoryid_id", "dbo.Category", "id");
        }
    }
}
