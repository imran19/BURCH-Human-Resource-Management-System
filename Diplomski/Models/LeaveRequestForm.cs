using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Diplomski.Models
{
    public class LeaveRequestForm
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Department is required")]
        [Display(Name = "Department")]
        public string Department { get; set; }


        [Required(ErrorMessage = "Firstname is required")]
        [Display(Name = "Firstname")]
        public string Firstname { get; set; }


        [Required(ErrorMessage = "Lastname is required")]
        [Display(Name = "Lastname")]
        public string Lastname { get; set; }
       
    
        [Required(ErrorMessage = "Title is required")]// kao profesor, assistant, dean
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Date of Request  is required")]
        [DataType(DataType.Date)]
        public DateTime DateOfRequest { get; set; }

        [Required(ErrorMessage = "Begining of leave  is required")]
        [DataType(DataType.Date)]
        public DateTime BeginningOfLeave { get; set; }

        [Required(ErrorMessage = "End of leave  is required")]
        [DataType(DataType.Date)]
        public DateTime EndOfLeave { get; set; }

        [Required(ErrorMessage = "ID is required")]
        [Display(Name = "ID")]
        public int EmployeeRegNum { get; set; }

        [Required(ErrorMessage = "Leave Type is required")]
        [Display(Name = "Leave Type")]
        public string LeaveType { get; set; }
        //public bool? AnnualLeave { get; set; }
        //public bool? LeaveDueToAnExcuse { get; set; }
        //public bool? LeaveDueToAnIllness { get; set; }
        //public bool? LeaveWithoutPay { get; set; }


        [Required(ErrorMessage = "Explanations is required")]
        [Display(Name = "Explanation of leave")]
        public string Explanation { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Address on leave")]
        public string AddressOnLeave { get; set; }

        [Required(ErrorMessage = "Telephone is required")]
        [Display(Name = "Telephone on leave")]
        public string TelephoneOnLeave { get; set; }

        [Required(ErrorMessage = "Verification is required")]
        [Display(Name = "Verification")]
        public bool Signature { get; set; }

        public string ExplanationForRejection { get; set; }

       public bool? HeadCheckbox { get; set; }

        [DataType(DataType.Date)]
        public DateTime? HeadApprovedDate { get; set; }

        public bool?  DeanValidation { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DeanApprovedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? StartingDateOfEmployment { get; set; }

        public int DurationOfLeave { get; set; }

        public bool? HRMValidation { get; set; }

        [DataType(DataType.Date)]
        public DateTime? HRMApprovedDate { get; set; }

        public int UserID { get; set; }
        public User User { get; set; }


        public string StatusHead { get; set; }
        public string StatusDean { get; set; }
        public string StatusHRM { get; set; }



    }
}