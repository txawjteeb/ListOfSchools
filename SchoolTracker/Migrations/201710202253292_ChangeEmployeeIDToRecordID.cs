namespace SchoolTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeEmployeeIDToRecordID : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Staff");
            DropColumn("dbo.Staff", "EmployeeID");
            AddColumn("dbo.Staff", "RecordID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Staff", "RecordID");
            AddColumn("dbo.Staff", "EmployeeID", c => c.Int(nullable: false, identity: false));
        }
        
        public override void Down()
        {
            AddColumn("dbo.Staff", "EmployeeID", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Staff");
            DropColumn("dbo.Staff", "RecordID");
            AddPrimaryKey("dbo.Staff", "EmployeeID");
        }
    }
}
