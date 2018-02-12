namespace SchoolTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSchoolIDToAccountabilityModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accountability", "SchoolID", c => c.Int(nullable: false));
            DropColumn("dbo.Accountability", "Testing");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accountability", "Testing", c => c.String());
            DropColumn("dbo.Accountability", "SchoolID");
        }
    }
}
