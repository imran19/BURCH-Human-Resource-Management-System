using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Diplomski.Models
{
    public class Faculty
    {

        //public int Id { get; set; }
        //public string FacultyType { get; set; }


        //  public int DepartmentId { get; set; }
        //public Departments Department { get; set; } //treba li ovaj?

        // public List<Department> Departments { get; set; }
        [Key]
        public string FacultyName { get; set; }
    }
}