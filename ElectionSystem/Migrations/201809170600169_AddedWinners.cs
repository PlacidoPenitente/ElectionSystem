namespace ElectionSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedWinners : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Positions", "MinimumNoOfWinners", c => c.Int(nullable: false));
            AddColumn("dbo.Positions", "MaximumNoOfWinners", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Positions", "MaximumNoOfWinners");
            DropColumn("dbo.Positions", "MinimumNoOfWinners");
        }
    }
}
