namespace SchoolTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SchoolDistrict : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SchoolDistrict",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SchoolName = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        MainPhone = c.String(),
                        Website = c.String(),
                        NumberOfStudents = c.Int(nullable: false),
                        CountyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.School", "DistrictID", c => c.Int(nullable: false));
            DropColumn("dbo.School", "SchoolOrDistrict");
            DropColumn("dbo.School", "CountyID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.School", "CountyID", c => c.Int(nullable: false));
            AddColumn("dbo.School", "SchoolOrDistrict", c => c.Boolean(nullable: false));
            DropColumn("dbo.School", "DistrictID");
            DropTable("dbo.SchoolDistrict");
        }
    }
}
