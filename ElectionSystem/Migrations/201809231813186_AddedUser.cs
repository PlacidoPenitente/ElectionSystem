namespace ElectionSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUser : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Voters", new[] { "Username" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Voters", "Username", unique: true);
        }
    }
}
