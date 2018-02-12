namespace SchoolTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestingHowMigrationWorksDemo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accountability", "Testing", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accountability", "Testing");
        }
    }
}
