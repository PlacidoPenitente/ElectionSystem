namespace ElectionSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedByDateAddedAndDateModified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ballots", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Ballots", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Ballots", "ModifiedBy_Id", c => c.Int());
            AddColumn("dbo.Voters", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Voters", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Voters", "ModifiedBy_Id", c => c.Int());
            AddColumn("dbo.Candidacies", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Candidacies", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Candidacies", "ModifiedBy_Id", c => c.Int());
            AddColumn("dbo.Parties", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Parties", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Parties", "ModifiedBy_Id", c => c.Int());
            AddColumn("dbo.Positions", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Positions", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Positions", "ModifiedBy_Id", c => c.Int());
            AddColumn("dbo.Elections", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Elections", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Elections", "ModifiedBy_Id", c => c.Int());
            AddColumn("dbo.Users", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "ModifiedBy_Id", c => c.Int());
            AddColumn("dbo.Votes", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Votes", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Votes", "ModifiedBy_Id", c => c.Int());
            CreateIndex("dbo.Ballots", "ModifiedBy_Id");
            CreateIndex("dbo.Users", "ModifiedBy_Id");
            CreateIndex("dbo.Voters", "ModifiedBy_Id");
            CreateIndex("dbo.Candidacies", "ModifiedBy_Id");
            CreateIndex("dbo.Parties", "ModifiedBy_Id");
            CreateIndex("dbo.Positions", "ModifiedBy_Id");
            CreateIndex("dbo.Elections", "ModifiedBy_Id");
            CreateIndex("dbo.Votes", "ModifiedBy_Id");
            AddForeignKey("dbo.Users", "ModifiedBy_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Ballots", "ModifiedBy_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Voters", "ModifiedBy_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Candidacies", "ModifiedBy_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Parties", "ModifiedBy_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Elections", "ModifiedBy_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Positions", "ModifiedBy_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Votes", "ModifiedBy_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Votes", "ModifiedBy_Id", "dbo.Users");
            DropForeignKey("dbo.Positions", "ModifiedBy_Id", "dbo.Users");
            DropForeignKey("dbo.Elections", "ModifiedBy_Id", "dbo.Users");
            DropForeignKey("dbo.Parties", "ModifiedBy_Id", "dbo.Users");
            DropForeignKey("dbo.Candidacies", "ModifiedBy_Id", "dbo.Users");
            DropForeignKey("dbo.Voters", "ModifiedBy_Id", "dbo.Users");
            DropForeignKey("dbo.Ballots", "ModifiedBy_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "ModifiedBy_Id", "dbo.Users");
            DropIndex("dbo.Votes", new[] { "ModifiedBy_Id" });
            DropIndex("dbo.Elections", new[] { "ModifiedBy_Id" });
            DropIndex("dbo.Positions", new[] { "ModifiedBy_Id" });
            DropIndex("dbo.Parties", new[] { "ModifiedBy_Id" });
            DropIndex("dbo.Candidacies", new[] { "ModifiedBy_Id" });
            DropIndex("dbo.Voters", new[] { "ModifiedBy_Id" });
            DropIndex("dbo.Users", new[] { "ModifiedBy_Id" });
            DropIndex("dbo.Ballots", new[] { "ModifiedBy_Id" });
            DropColumn("dbo.Votes", "ModifiedBy_Id");
            DropColumn("dbo.Votes", "DateModified");
            DropColumn("dbo.Votes", "DateAdded");
            DropColumn("dbo.Users", "ModifiedBy_Id");
            DropColumn("dbo.Users", "DateModified");
            DropColumn("dbo.Users", "DateAdded");
            DropColumn("dbo.Elections", "ModifiedBy_Id");
            DropColumn("dbo.Elections", "DateModified");
            DropColumn("dbo.Elections", "DateAdded");
            DropColumn("dbo.Positions", "ModifiedBy_Id");
            DropColumn("dbo.Positions", "DateModified");
            DropColumn("dbo.Positions", "DateAdded");
            DropColumn("dbo.Parties", "ModifiedBy_Id");
            DropColumn("dbo.Parties", "DateModified");
            DropColumn("dbo.Parties", "DateAdded");
            DropColumn("dbo.Candidacies", "ModifiedBy_Id");
            DropColumn("dbo.Candidacies", "DateModified");
            DropColumn("dbo.Candidacies", "DateAdded");
            DropColumn("dbo.Voters", "ModifiedBy_Id");
            DropColumn("dbo.Voters", "DateModified");
            DropColumn("dbo.Voters", "DateAdded");
            DropColumn("dbo.Ballots", "ModifiedBy_Id");
            DropColumn("dbo.Ballots", "DateModified");
            DropColumn("dbo.Ballots", "DateAdded");
        }
    }
}
