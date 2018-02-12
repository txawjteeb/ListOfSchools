namespace SchoolTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SchoolVMChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SchoolVMs", "DistrictID", c => c.Int(nullable: false));
            DropColumn("dbo.SchoolVMs", "SchoolOrDistrict");
            DropColumn("dbo.SchoolVMs", "CountyID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SchoolVMs", "CountyID", c => c.Int(nullable: false));
            AddColumn("dbo.SchoolVMs", "SchoolOrDistrict", c => c.Boolean(nullable: false));
            DropColumn("dbo.SchoolVMs", "DistrictID");
        }
    }
}
