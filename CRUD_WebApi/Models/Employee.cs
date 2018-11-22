using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD_WebApi.Models
{
    public class Employee
    {
        [Display(Name = "EmployeeId")]
        public int EmpID { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "Contact No")]
        public string MobileNo { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> birthdate { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}