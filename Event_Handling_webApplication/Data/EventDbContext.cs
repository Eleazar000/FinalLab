using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Event_Handling_webApplication.Data
{
    public class EventDbContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public EventDbContext() : base("name=EventDbContext")
        {
        }
        
        public DbSet<Event_Handling_webApplication.Models.tbevent> tbevents { get; set; }
        public DbSet<Event_Handling_webApplication.Models.Event_Type> Event_Types { get; internal set; }

        public DbSet<Event_Handling_webApplication.Models.login> logins { get; set; }
    }
}
