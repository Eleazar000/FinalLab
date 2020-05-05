using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Event_Handling_webApplication.Models
{
    public partial class login
    {
        [Key]
        public int login_ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}