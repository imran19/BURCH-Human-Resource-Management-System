using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Diplomski.Models
{
    public class LeaveType
    {
        [Key]
        public string LeaveName { get; set; }
    }
}