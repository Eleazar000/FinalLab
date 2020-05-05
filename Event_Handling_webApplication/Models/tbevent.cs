using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Event_Handling_webApplication.Models
{
    public partial class tbevent
    {
        [Key]
        public virtual int event_id { get; set; }
        public virtual string event_type { get; set; }
        public virtual string title { get; set; }
        public virtual string description { get; set; }
        public virtual Nullable<System.DateTime> st_date { get; set; }
        public virtual Nullable<System.DateTime> e_date { get; set; }
        public virtual string org_name { get; set; }
        public virtual string org_contact { get; set; }
        public virtual Nullable<int> max_ticket { get; set; }
        public virtual Nullable<int> available_ticket { get; set; }
        public virtual string city { get; set; }
        public virtual string state { get; set; }
    }
}