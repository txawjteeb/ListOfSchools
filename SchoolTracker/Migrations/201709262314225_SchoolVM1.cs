namespace SchoolTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SchoolVM1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Schools", newName: "SchoolVMs");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.SchoolVMs", newName: "Schools");
        }
    }
}
