using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Event_Handling_webApplication.Models
{
    public partial class Event_Type
    {
        [Key]
        public int event_type_ID { get; set; }
        public string event_type1 { get; set; }
    }
}
