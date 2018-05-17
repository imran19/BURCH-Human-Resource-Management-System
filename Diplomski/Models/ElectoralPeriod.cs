using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Diplomski.Models
{
    public class ElectoralPeriod
    {
        [Key]
        public string ElectoralPeriodName { get; set; }



        // public Faculty Faculties { get; set; }

    }
}