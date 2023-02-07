using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EMaS_MVC.Models.ViewModel
{
    public class ErpPrEmployeeList
    {
        public string EmpName { get; set; }
        public string EmpPreAddres { get; set; }
        public string EmpPerAddress { get; set; }
        public string EmpContactNum { get; set; }
        public byte[] EmpJoiningDate { get; set; }
        public string EmpStatus { get; set; }
        public string EmpTinNo { get; set; }
        public string CmpBranchId { get; set; }

        [Key]
        public long? EmpId { get; set; }
        public string EmpComments { get; set; }
        public string EmpTitle { get; set; }
        public string DptId { get; set; }
        public string DsgId { get; set; }
        public string EmpGender { get; set; }
        public double? LveApprovalPerm { get; set; }
        public double? EmpQuantity { get; set; }
        public string EmpIndividual { get; set; }

        public double? SysUsrId { get; set; }
        public string EmpCode { get; set; }
        public string EmpPic { get; set; }
        public string EmpSignature { get; set; }
        public string EmpFatherName { get; set; }
        public string EmpMotherName { get; set; }
    }
}