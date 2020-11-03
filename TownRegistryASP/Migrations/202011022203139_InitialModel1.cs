namespace TownRegistryASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Citizens",
                c => new
                    {
                        CitizenID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Gender = c.String(),
                        PlaceOfBirthID = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        PlaceOfDeathID = c.Int(nullable: false),
                        DateOfDeath = c.DateTime(nullable: false),
                        Status = c.String(),
                        Occupation = c.String(),
                    })
                .PrimaryKey(t => t.CitizenID);
            
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        PlaceID = c.Int(nullable: false, identity: true),
                        Street1 = c.String(),
                        Street2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zipcode = c.String(),
                    })
                .PrimaryKey(t => t.PlaceID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Places");
            DropTable("dbo.Citizens");
        }
    }
}
