using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Diplomski.Models
{
    public class Title
    {
        //public int Id { get; set; }
        //public string TitleType { get; set; }

        //    public int UserId { get; set; } //moze se koristiti i Employee registration number
        //  public User User { get; set; }

        [Key]
        public string TitleName { get; set; }


    }
}