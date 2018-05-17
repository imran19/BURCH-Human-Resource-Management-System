using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Diplomski.Models
{
    public class Department
    {
        //public int Id { get; set; }
        //public string DepartmentName { get; set; }



        //public Faculty Faculties { get; set; }



        //konekciju napraviti

        [Key]
        public string DepartmentName { get; set; }
    }
}