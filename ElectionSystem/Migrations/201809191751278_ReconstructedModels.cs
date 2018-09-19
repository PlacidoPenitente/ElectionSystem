namespace ElectionSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReconstructedModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Voters", "Party_Id", "dbo.Parties");
            DropForeignKey("dbo.Voters", "Type_Id", "dbo.Positions");
            DropIndex("dbo.Voters", new[] { "Party_Id" });
            DropIndex("dbo.Voters", new[] { "Type_Id" });
            CreateTable(
                "dbo.Ballots",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Voter_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Voters", t => t.Voter_Id)
                .Index(t => t.Voter_Id);
            
            CreateTable(
                "dbo.Candidacies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Candidate_Id = c.Int(),
                        Party_Id = c.Int(),
                        Position_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Voters", t => t.Candidate_Id)
                .ForeignKey("dbo.Parties", t => t.Party_Id)
                .ForeignKey("dbo.Positions", t => t.Position_Id)
                .Index(t => t.Candidate_Id)
                .Index(t => t.Party_Id)
                .Index(t => t.Position_Id);
            
            CreateTable(
                "dbo.Elections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        IsOpen = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 64),
                        Password = c.String(nullable: false, maxLength: 64),
                        AccountType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Username, unique: true);
            
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ballot_Id = c.Int(),
                        Candidacy_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ballots", t => t.Ballot_Id)
                .ForeignKey("dbo.Candidacies", t => t.Candidacy_Id)
                .Index(t => t.Ballot_Id)
                .Index(t => t.Candidacy_Id);
            
            AddColumn("dbo.Positions", "Election_Id", c => c.Int());
            AlterColumn("dbo.Voters", "FirstName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Voters", "LastName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Voters", "Address", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Parties", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Positions", "Name", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Parties", "Name", unique: true);
            CreateIndex("dbo.Positions", "Election_Id");
            AddForeignKey("dbo.Positions", "Election_Id", "dbo.Elections", "Id");
            DropColumn("dbo.Voters", "AccountType");
            DropColumn("dbo.Voters", "Password");
            DropColumn("dbo.Voters", "Discriminator");
            DropColumn("dbo.Voters", "Party_Id");
            DropColumn("dbo.Voters", "Type_Id");
            DropColumn("dbo.Positions", "MinimumNoOfWinners");
            DropColumn("dbo.Positions", "MaximumNoOfWinners");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Positions", "MaximumNoOfWinners", c => c.Int(nullable: false));
            AddColumn("dbo.Positions", "MinimumNoOfWinners", c => c.Int(nullable: false));
            AddColumn("dbo.Voters", "Type_Id", c => c.Int());
            AddColumn("dbo.Voters", "Party_Id", c => c.Int());
            AddColumn("dbo.Voters", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Voters", "Password", c => c.String());
            AddColumn("dbo.Voters", "AccountType", c => c.Int(nullable: false));
            DropForeignKey("dbo.Votes", "Candidacy_Id", "dbo.Candidacies");
            DropForeignKey("dbo.Votes", "Ballot_Id", "dbo.Ballots");
            DropForeignKey("dbo.Candidacies", "Position_Id", "dbo.Positions");
            DropForeignKey("dbo.Positions", "Election_Id", "dbo.Elections");
            DropForeignKey("dbo.Candidacies", "Party_Id", "dbo.Parties");
            DropForeignKey("dbo.Candidacies", "Candidate_Id", "dbo.Voters");
            DropForeignKey("dbo.Ballots", "Voter_Id", "dbo.Voters");
            DropIndex("dbo.Votes", new[] { "Candidacy_Id" });
            DropIndex("dbo.Votes", new[] { "Ballot_Id" });
            DropIndex("dbo.Users", new[] { "Username" });
            DropIndex("dbo.Elections", new[] { "Name" });
            DropIndex("dbo.Positions", new[] { "Election_Id" });
            DropIndex("dbo.Parties", new[] { "Name" });
            DropIndex("dbo.Candidacies", new[] { "Position_Id" });
            DropIndex("dbo.Candidacies", new[] { "Party_Id" });
            DropIndex("dbo.Candidacies", new[] { "Candidate_Id" });
            DropIndex("dbo.Ballots", new[] { "Voter_Id" });
            AlterColumn("dbo.Positions", "Name", c => c.String());
            AlterColumn("dbo.Parties", "Name", c => c.String());
            AlterColumn("dbo.Voters", "Address", c => c.String());
            AlterColumn("dbo.Voters", "LastName", c => c.String());
            AlterColumn("dbo.Voters", "FirstName", c => c.String());
            DropColumn("dbo.Positions", "Election_Id");
            DropTable("dbo.Votes");
            DropTable("dbo.Users");
            DropTable("dbo.Elections");
            DropTable("dbo.Candidacies");
            DropTable("dbo.Ballots");
            CreateIndex("dbo.Voters", "Type_Id");
            CreateIndex("dbo.Voters", "Party_Id");
            AddForeignKey("dbo.Voters", "Type_Id", "dbo.Positions", "Id");
            AddForeignKey("dbo.Voters", "Party_Id", "dbo.Parties", "Id");
        }
    }
}
