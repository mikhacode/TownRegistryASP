namespace TownRegistryASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyNullableDatesToCitizen : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Citizens", "DateOfBirth", c => c.DateTime());
            AlterColumn("dbo.Citizens", "DateOfDeath", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Citizens", "DateOfDeath", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Citizens", "DateOfBirth", c => c.DateTime(nullable: false));
        }
    }
}
