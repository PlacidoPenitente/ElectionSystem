namespace ElectionSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedModifiedByInUsers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "ModifiedBy_Id", "dbo.Users");
            DropIndex("dbo.Users", new[] { "ModifiedBy_Id" });
            DropColumn("dbo.Users", "DateAdded");
            DropColumn("dbo.Users", "DateModified");
            DropColumn("dbo.Users", "ModifiedBy_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "ModifiedBy_Id", c => c.Int());
            AddColumn("dbo.Users", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "DateAdded", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Users", "ModifiedBy_Id");
            AddForeignKey("dbo.Users", "ModifiedBy_Id", "dbo.Users", "Id");
        }
    }
}
