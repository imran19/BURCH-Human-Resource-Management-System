using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Diplomski.Models
{
    public class Country
    {
        //public int CountryID { get; set; }        
        //public string CountryName { get; set; }
        //public override string ToString() { return CountryName; }


        // // public Faculty Faculties { get; set; }


        [Key]
        public string CountryName { get; set; }

    }
}