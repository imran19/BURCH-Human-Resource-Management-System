using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Diplomski.Models
{
    public class EmploymentStatus
    {


        [Key]
        public string EmploymentName { get; set; }

    }
}