namespace SchoolTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImageLinkToViewModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SchoolVMs", "ImageLink", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SchoolVMs", "ImageLink");
        }
    }
}
