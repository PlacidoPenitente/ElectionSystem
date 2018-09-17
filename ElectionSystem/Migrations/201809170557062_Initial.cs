namespace ElectionSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Voters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Birthdate = c.DateTime(nullable: false),
                        Gender = c.Int(nullable: false),
                        Address = c.String(),
                        Photo = c.String(),
                        AccountType = c.Int(nullable: false),
                        Password = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Party_Id = c.Int(),
                        Type_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parties", t => t.Party_Id)
                .ForeignKey("dbo.Positions", t => t.Type_Id)
                .Index(t => t.Party_Id)
                .Index(t => t.Type_Id);
            
            CreateTable(
                "dbo.Parties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Logo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Voters", "Type_Id", "dbo.Positions");
            DropForeignKey("dbo.Voters", "Party_Id", "dbo.Parties");
            DropIndex("dbo.Voters", new[] { "Type_Id" });
            DropIndex("dbo.Voters", new[] { "Party_Id" });
            DropTable("dbo.Positions");
            DropTable("dbo.Parties");
            DropTable("dbo.Voters");
        }
    }
}
