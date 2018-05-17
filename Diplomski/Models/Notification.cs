using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diplomski.Models
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public int RequestingUserId { get; set; }
        public User RequestingUser { get; set; }
        public int ApprovingUserId { get; set; }
        public User ApprovingUser { get; set; }
        public string Status { get; set; }
        public int LeaveRequestFormId { get; set;}
        public LeaveRequestForm LeaveRequestForm { get; set; }
    }
}