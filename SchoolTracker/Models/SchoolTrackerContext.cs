using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SchoolTracker.Models
{
    public class SchoolTrackerContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public SchoolTrackerContext() : base("name=SchoolTrackerContext")
        {
        }

        public System.Data.Entity.DbSet<SchoolTracker.Models.Accountability> Accountabilities { get; set; }

        public System.Data.Entity.DbSet<SchoolTracker.Models.CleanAirChampion> CleanAirChampions { get; set; }

        public System.Data.Entity.DbSet<SchoolTracker.Models.CommunicationTool> CommunicationTools { get; set; }

        public System.Data.Entity.DbSet<SchoolTracker.Models.Contact> Contacts { get; set; }

        public System.Data.Entity.DbSet<SchoolTracker.Models.ExtraActivites> ExtraActivites { get; set; }

        public System.Data.Entity.DbSet<SchoolTracker.Models.Material> Materials { get; set; }

        public System.Data.Entity.DbSet<SchoolTracker.Models.MeetingTracker> MeetingTrackers { get; set; }

        public System.Data.Entity.DbSet<SchoolTracker.Models.MeetingType> MeetingTypes { get; set; }

        public System.Data.Entity.DbSet<SchoolTracker.Models.Note> Notes { get; set; }

        public System.Data.Entity.DbSet<SchoolTracker.Models.ParentsCommunication> ParentsCommunications { get; set; }

        public System.Data.Entity.DbSet<SchoolTracker.Models.RAANNotification> RAANNotifications { get; set; }

        public System.Data.Entity.DbSet<SchoolTracker.Models.School> Schools { get; set; }
    }
}
