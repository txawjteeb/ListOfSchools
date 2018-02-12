namespace SchoolTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingImageLink : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contact", "ImageLink", c => c.String());
            AddColumn("dbo.County", "ImageLink", c => c.String());
            AddColumn("dbo.SchoolDistrict", "ImageLink", c => c.String());
            AddColumn("dbo.School", "ImageLink", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.School", "ImageLink");
            DropColumn("dbo.SchoolDistrict", "ImageLink");
            DropColumn("dbo.County", "ImageLink");
            DropColumn("dbo.Contact", "ImageLink");
        }
    }
}
