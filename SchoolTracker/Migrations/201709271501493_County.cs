namespace SchoolTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class County : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.County",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CountyName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.County");
        }
    }
}
