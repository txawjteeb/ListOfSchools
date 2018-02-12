namespace SchoolTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SchoolVM : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SchoolVMs",
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
                        SchoolOrDistrict = c.Boolean(nullable: false),
                        CountyID = c.Int(nullable: false),
                        ContactFirstName = c.String(),
                        ContactLastName = c.String(),
                        ContactTitle = c.String(),
                        ContactPhone = c.String(),
                        ContactEmail = c.String(),
                        PrimaryOrSecondary = c.Boolean(nullable: false),
                        Coordinator = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SchoolVMs");
        }
    }
}
