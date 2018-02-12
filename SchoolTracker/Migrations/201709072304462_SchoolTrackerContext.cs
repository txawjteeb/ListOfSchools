namespace SchoolTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SchoolTrackerContext : DbMigration
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
            
            CreateTable(
                "dbo.CleanAirChampion",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ContactFirstName = c.String(),
                        ContactLastName = c.String(),
                        ContactTitle = c.String(),
                        ContactPhone = c.String(),
                        ContactEmail = c.String(),
                        PrimaryOrSecondary = c.Boolean(nullable: false),
                        ProjectDescription = c.String(),
                        AmountFunded = c.Int(nullable: false),
                        DateFunded = c.DateTime(nullable: false),
                        AttachPhotos = c.String(),
                        FollowUpReport = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CommunicationTool",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ContactFirstName = c.String(),
                        ContactLastName = c.String(),
                        ContactTitle = c.String(),
                        ContactPhone = c.String(),
                        ContactEmail = c.String(),
                        PrimaryOrSecondary = c.Boolean(nullable: false),
                        Coordinator = c.Boolean(nullable: false),
                        School_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ExtraActivities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CalendarProgram = c.Boolean(nullable: false),
                        VideoContest = c.Boolean(nullable: false),
                        SportsOutreach = c.Boolean(nullable: false),
                        Workshops = c.Boolean(nullable: false),
                        ScienceDays = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Material",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IdlingSign = c.Int(nullable: false),
                        Brochure = c.Int(nullable: false),
                        Poster = c.Int(nullable: false),
                        PromoItem = c.Int(nullable: false),
                        Curricula = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MeetingTracker",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MeetingDate = c.DateTime(nullable: false),
                        ContactID = c.Int(nullable: false),
                        NoteID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MeetingType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Note",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ParentsCommunication",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ClassRoomDojo = c.Boolean(nullable: false),
                        PeachJar = c.Boolean(nullable: false),
                        EduText = c.Boolean(nullable: false),
                        etc = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RAANNotification",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SchoolOffice = c.Boolean(nullable: false),
                        DistrictOffice = c.Boolean(nullable: false),
                        Teachers = c.Boolean(nullable: false),
                        AthleticDirector = c.Boolean(nullable: false),
                        Widget = c.Boolean(nullable: false),
                        SmartPhoneApp = c.Boolean(nullable: false),
                        READ = c.Boolean(nullable: false),
                        FlagRelying = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.School",
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
                })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.School");
            DropTable("dbo.RAANNotification");
            DropTable("dbo.ParentsCommunication");
            DropTable("dbo.Note");
            DropTable("dbo.MeetingType");
            DropTable("dbo.MeetingTracker");
            DropTable("dbo.Material");
            DropTable("dbo.ExtraActivites");
            DropTable("dbo.Contact");
            DropTable("dbo.CommunicationTool");
            DropTable("dbo.CleanAirChampion");
            DropTable("dbo.Accountability");
        }
    }
}
