namespace SchoolTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accountability",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OCStaffAssigned = c.String(),
                        DateOfContact = c.DateTime(nullable: false),
                        StaffLastContacted = c.String(),
                        NoteID = c.Int(nullable: false),
                        ReadActiveOrNot = c.Boolean(nullable: false),
                        IdleSignOrNot = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Accountability");
        }
    }
}
