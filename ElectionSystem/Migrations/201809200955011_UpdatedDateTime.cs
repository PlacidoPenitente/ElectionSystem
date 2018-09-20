namespace ElectionSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ballots", "DateAdded", c => c.DateTime());
            AlterColumn("dbo.Ballots", "DateModified", c => c.DateTime());
            AlterColumn("dbo.Voters", "Birthdate", c => c.DateTime());
            AlterColumn("dbo.Voters", "DateAdded", c => c.DateTime());
            AlterColumn("dbo.Voters", "DateModified", c => c.DateTime());
            AlterColumn("dbo.Candidacies", "DateAdded", c => c.DateTime());
            AlterColumn("dbo.Candidacies", "DateModified", c => c.DateTime());
            AlterColumn("dbo.Parties", "DateAdded", c => c.DateTime());
            AlterColumn("dbo.Parties", "DateModified", c => c.DateTime());
            AlterColumn("dbo.Positions", "DateAdded", c => c.DateTime());
            AlterColumn("dbo.Positions", "DateModified", c => c.DateTime());
            AlterColumn("dbo.Elections", "DateAdded", c => c.DateTime());
            AlterColumn("dbo.Elections", "DateModified", c => c.DateTime());
            AlterColumn("dbo.Votes", "DateAdded", c => c.DateTime());
            AlterColumn("dbo.Votes", "DateModified", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Votes", "DateModified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Votes", "DateAdded", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Elections", "DateModified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Elections", "DateAdded", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Positions", "DateModified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Positions", "DateAdded", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Parties", "DateModified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Parties", "DateAdded", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Candidacies", "DateModified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Candidacies", "DateAdded", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Voters", "DateModified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Voters", "DateAdded", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Voters", "Birthdate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Ballots", "DateModified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Ballots", "DateAdded", c => c.DateTime(nullable: false));
        }
    }
}
