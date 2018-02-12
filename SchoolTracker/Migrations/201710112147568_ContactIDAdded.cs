namespace SchoolTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContactIDAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.School", "ContactID", c => c.Int(nullable: false));
            DropColumn("dbo.Contact", "School_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contact", "School_ID", c => c.Int(nullable: false));
            DropColumn("dbo.School", "ContactID");
        }
    }
}
