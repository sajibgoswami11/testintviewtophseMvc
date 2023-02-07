using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EMaS_MVC.Models
{
    public class CmSystemMenu
    {
        [Key]
        [Display(Name = "MENU ID")]
        public string SYS_MENU_ID { get; set; }

        [Display(Name = "MENU TITLE")]
        public string SYS_MENU_TITLE { get; set; }

        [Display(Name = "MENU FILE")]
        public string SYS_MENU_FILE { get; set; }

        [Display(Name = "MENU PARENT")]
        public string SYS_MENU_PARENT { get; set; }

        [Display(Name = "BRANCH")]
        public string CMP_BRANCH_ID { get; set; }

        [Display(Name = "TYPE")]
        public string SYS_MENU_TYPE { get; set; }

        [Display(Name = "SERIAL")]
        public string SYS_MENU_SERIAL { get; set; }

        [Display(Name = "DETAILS")]
        public string SYS_MENU_DETAILS { get; set; }

        [Display(Name = "FOLDER NAME")]
        public string FOLDER_NAME { get; set; }
    }
}