namespace SchoolTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SchoolTrackerContext1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.School", "CountyID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.School", "CountyID");
        }
    }
}
