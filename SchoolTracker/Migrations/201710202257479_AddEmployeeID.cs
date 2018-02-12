namespace SchoolTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployeeID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Staff", "EmployeeID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Staff", "EmployeeID");
        }
    }
}
