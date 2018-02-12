namespace SchoolTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContactsAddID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SchoolVMs", "ContactID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SchoolVMs", "ContactID");
        }
    }
}
