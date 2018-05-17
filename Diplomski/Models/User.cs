using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Diplomski.Models
{
    public class User
    {
        public int Id { get; set; }
        //   public int RoleId  { get; set; }
        //   public Role Role { get; set; }


        //[Required(ErrorMessage ="Image is required")]
        //[Display(Name ="Profile Picture")]
        public byte[] Image { get; set; }  // za sliku


        [Required(ErrorMessage = "Firstname is required")]
        [Display(Name = "Firstname")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Lastname is required")]
        [Display(Name = "Lastname")]
        public string Lastname { get; set; }


        [Required(ErrorMessage = "ID is required")]
        [Display(Name = "ID")]
        public int EmployeeRegNum { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Address")]
        public string Address { get; set; }


        [Required(ErrorMessage = "Title is required")]// kao profesor, assistant, dean
        [Display(Name = "Title")]
        public string Title { get; set; }

        public IEnumerable<SelectListItem> Titles { get; set; }


        [Required(ErrorMessage = "Faculty is required")]
        [Display(Name = "Faculty")]
        public string Faculty { get; set; }

        //  public IEnumerable<SelectListItem> Faculties { get; set; }

        [Required(ErrorMessage = "Department is required")]
        [Display(Name = "Department")]
        public string Department { get; set; }

        // public IEnumerable<SelectListItem> Departments { get; set; }    //This property will hold all available states for selection


        [Required(ErrorMessage = "Employment Status is required")]
        [Display(Name = "Employment Status")]
        public string EmploymentStatus { get; set; }

        // public IEnumerable<SelectListItem> EmploymentStatuses { get; set; } 

        //[Required(ErrorMessage = "Nationality is required")]
        //[Display(Name = "Nationality")]
        //public string Nationality { get; set; }


        [Required(ErrorMessage = "Country is required")]
        [Display(Name = "Country")]
        public string CountryName { get; set; }

        // public IEnumerable<SelectListItem> Nationalities { get; set; }
        [Required(ErrorMessage = "Date of Birth  is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Electoral Period is required")]  //sistent 4 god,viši asistent i docent 5 god, vanredni profesor 6 god i redovni profesor neodređeno,
        [Display(Name = "Electoral Period")]
        public string ElectoralPeriod { get; set; }

        //public IEnumerable<SelectListItem> ElectoralPeriods { get; set; }

        //  [Required(ErrorMessage = "Contract Expiration is required")]
        // [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]      
        [Display(Name = "Contract Expiration")]
        public DateTime ContractExpiration { get; set; }

        [Required(ErrorMessage = "Number of leave days is required")]
        [Display(Name = "Number of leave days")]
        public int NumberOfLeaveDays { get; set; }

        [Required(ErrorMessage = "Stay in Bosnia is required")]
        [Display(Name = "Stay Approved")]
        public string Stay { get; set; }

        //public IEnumerable<SelectListItem> StayOptions { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password must be 8 characters minimum")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Re-enter is required")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Chief HR Manager")]
        public bool? ChiefHRManager { get; set; }

        public bool? HeadOfDep { get; set; }

        public bool? Dean { get; set; } // dodano za slucaj da ne radi

        public bool? OrdinaryHRManager { get; set; }


    }
}