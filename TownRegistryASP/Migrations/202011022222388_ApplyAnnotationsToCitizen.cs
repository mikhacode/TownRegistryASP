namespace TownRegistryASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationsToCitizen : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Citizens", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Citizens", "LastName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Citizens", "LastName", c => c.String());
            AlterColumn("dbo.Citizens", "FirstName", c => c.String());
        }
    }
}
