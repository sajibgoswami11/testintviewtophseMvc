using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EMaS_MVC.Models.ViewModel
{
    public class UserViewModel
    {
        
        [Display(Name = "USER GROUP")]
        public string SYS_USR_GRP_ID { get; set; }

        [Display(Name = "USER ID")]
        public string SYS_USR_ID { get; set; }

        [Display(Name = "USER NAME")]
        public string SYS_USR_DNAME { get; set; }

        [Display(Name = "LOGIN NAME")]
        public string SYS_USR_LOGIN_NAME { get; set; }

        public string SYS_USR_GRP_TITLE { get; set; }

        public string SYS_USR_PASS { get; set; }

        public string CMP_BRANCH_ID { get; set; }

        public string CMP_BRANCH_NAME { get; set; }

        public string COMPANY_ID { get; set; }

        public string DPT_ID { get; set; }

        public string DPT_NAME { get; set; }

        public string USER_ACTIVE { get; set; }

        public string SYS_USR_EMAIL { get; set; }

        public string USER_TYPE { get; set; }

        public string CMP_BRANCH_TYPE_ID { get; set; }

        public string COMPANY_NAME { get; set; }

        public string COMPANY_CODE { get; set; }

        public string SOFT_PKG_ID { get; set; }

        public string BRANCH_CODE { get; set; }
    }
}