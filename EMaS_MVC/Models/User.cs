using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EMaS_MVC.Models
{
    public class User
    {
        public string SYS_USR_GRP_ID { get; set; }
        
        [Key]
        public int SYS_USR_ID { get; set; }

        public string SYS_USR_LOGIN_NAME { get; set; }

        public string SYS_USR_PASS { get; set; }

        public string USER_TYPE { get; set; }
    }
}