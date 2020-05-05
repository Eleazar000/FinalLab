using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Event_Handling_webApplication.Models
{
    public class EventDBContext : DbContext
    {

        public EventDBContext(): base("name = EventDBContext")
        {

        }
        public DbSet<Event_Handling_webApplication.Models.tbevent> tbevents { get; set; }
        public DbSet<Event_Handling_webApplication.Models.Event_Type> Event_Types { get; set; }

        public DbSet<Event_Handling_webApplication.Models.login> logins { get; set; }

    }
}