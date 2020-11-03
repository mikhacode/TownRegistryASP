namespace TownRegistryASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyNullableIDToCitizen : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Citizens", "PlaceOfBirthID", c => c.Int());
            AlterColumn("dbo.Citizens", "PlaceOfDeathID", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Citizens", "PlaceOfDeathID", c => c.Int(nullable: false));
            AlterColumn("dbo.Citizens", "PlaceOfBirthID", c => c.Int(nullable: false));
        }
    }
}
