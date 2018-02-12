namespace SchoolTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStaffModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Staff",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        Region = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UserName = c.String(),
                        Extension = c.Int(nullable: false),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Staff");
        }
    }
}
