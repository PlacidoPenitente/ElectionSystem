namespace ElectionSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSlots : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Positions", "Slots", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Positions", "Slots");
        }
    }
}
