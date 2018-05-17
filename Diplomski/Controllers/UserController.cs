using Diplomski.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Diplomski.Controllers
{
    public class UserController : BaseController
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserLogin(User user)
        {
            user = db.Users
                .Where(u => u.Email == user.Email && u.Password == user.Password)
                .FirstOrDefault();
            if (user != null)
            {
                Session["user_id"] = user.Id;
                if (user.ChiefHRManager == true)
                    return RedirectToAction("HRMHome", "HeadHR");
                else
                    return RedirectToAction("userHome");
            }
            return View();
        }




  public ActionResult userHome()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Logoff()
        {
            Session["user_id"] = null;
            return RedirectToAction("Index", "Home");  // prvo je action a drugo je kontroler
        }



        //public ActionResult LeaveRequest()
        //{

        //    int? user_id = Session["user_id"] as int?;
        //    if (user_id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    return View();
        //}

        //[HttpPost]
        //public ActionResult LeaveRequest(LeaveRequestForm req)
        //{

        //    int? user_id = Session["user_id"] as int?;
        //    if (user_id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    if (ModelState.IsValid)
        //    {

        //        req.UserID = user_id ?? -1;
        //        //       req.Status = "Pending";
        //        req = db.LeaveRequestForms.Add(req);
        //        db.SaveChanges();

        //        Notification notification = new Notification();
        //        notification.RequestingUserId =(int) Session["user_id"];
        //        notification.Status = "Pending";
        //        notification.ApprovingUserId = 9;
        //        notification.LeaveRequestFormId = req.Id;




        //        db.Notifications.Add(notification);
        //        db.SaveChanges();
        //       // ModelState.Clear();
        //        // ViewBag.Message = account.Firstname + "Successfully registered.";
        //        return RedirectToAction("Home");
        //    }
        //    return View();

        //}


        public ActionResult Home()
        {
            return View();
        }


        public ActionResult LeaveRequest()
        {
            List<LeaveType> allLeaves = new List<LeaveType>();
            List<Department> allDepartments = new List<Department>();
            List<Title> allTitle = new List<Title>();

            allLeaves = db.LeaveTypes.OrderBy(a => a.LeaveName).ToList();
            allTitle = db.Titles.OrderBy(a => a.TitleName).ToList();
            allDepartments = db.Departments.OrderBy(a => a.DepartmentName).ToList();

            ViewBag.TitleName = new SelectList(allTitle, "TitleName", "TitleName");
            ViewBag.DepartmentName = new SelectList(allDepartments, "DepartmentName", "DepartmentName");
            ViewBag.LeaveName = new SelectList(allLeaves, "LeaveName", "LeaveName");

            int? user_id = Session["user_id"] as int?;
            if (user_id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View();
        }

        public ActionResult LeaveSubmitted()
        {
            return View();
        }


        [HttpPost]
        public ActionResult LeaveRequest(LeaveRequestForm req)
        {
            List<Department> allDepartments = new List<Department>();
            allDepartments = db.Departments.OrderBy(a => a.DepartmentName).ToList();
            ViewBag.DepartmentName = new SelectList(allDepartments, "DepartmentName", "DepartmentName", req.Department);

            List<Title> allTitle = new List<Title>();
            allTitle = db.Titles.OrderBy(a => a.TitleName).ToList();
            ViewBag.TitleName = new SelectList(allTitle, "TitleName", "TitleName", req.Title);


            List<LeaveType> allLeaves = new List<LeaveType>();
            allLeaves = db.LeaveTypes.OrderBy(a => a.LeaveName).ToList();
            ViewBag.LeaveName = new SelectList(allLeaves, "LeaveName", "LeaveName", req.LeaveType);

            int? user_id = Session["user_id"] as int?;
            if (user_id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (ModelState.IsValid)
            {

                req.UserID = user_id ?? -1;
                req.StatusHead = "Pending";
                req.StatusDean = "Pending";
                req.StatusHRM = "Pending";
                db.LeaveRequestForms.Add(req);
                db.SaveChanges();

                ModelState.Clear();
                // ViewBag.Message = account.Firstname + "Successfully registered.";
                return RedirectToAction("LeaveSubmitted");
            }
            return View();

        }

        public ActionResult ListOfLeaveRequests(string search)
        {
            int? user_id = Session["user_id"] as int?;
            var Leaves = db.LeaveRequestForms;
            List<LeaveRequestForm> leaves;

            if (!String.IsNullOrEmpty(search))
            {
                leaves = Leaves.Where(l => l.UserID == user_id &&
               l.StatusHead.Contains(search))
               .ToList();

            }
            else
            {
                leaves = Leaves.Where(l => l.UserID == user_id).ToList();
            }
            return View(leaves);
        }











        //public ActionResult Notifications()
        //{

        //    return View(db.Notifications.Where((notif => notif.ApprovingUserId == (int)Session["user_id"])));
        //}

        //public ActionResult SetStatus(int? id, string text)
        //{
        //    var r = db.Notifications.Find(id);
        //    if (r != null && text != null)
        //    {
        //        r.Status = text;
        //        if (text == "Accepted")
        //        {
        //            Notification notif = new Notification();
        //            notif.LeaveRequestFormId = r.LeaveRequestFormId;
        //            notif.RequestingUserId = r.RequestingUserId;
        //            notif.Status = "Pending";
        //            int toApprove = -1;
        //            if (notif.ApprovingUserId == 3)
        //            {
        //                toApprove = 8;
        //            }
        //            else if (notif.ApprovingUserId == 8)
        //            {
        //                toApprove = 10;
        //            }
        //            notif.ApprovingUserId = toApprove;
        //            db.Notifications.Add(notif);
        //        }
        //        db.SaveChanges();
        //    }
        //    return RedirectToAction("Reservations");
        //}

        //treba zamijeniti ove nece htjeti update ako ne moze da build

    }
}




