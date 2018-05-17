using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Diplomski.Controllers
{
    public class HeadController : BaseController
    {
        // GET: Head
        public ActionResult Index()
        {
            return View();
        }
        //tu je lista leave requesta
        public ViewResult ListOfLeaveRequests(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "Date_desc" : "Date";



            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;


            var users = from s in db.LeaveRequestForms
                        select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(s => s.Lastname.ToUpper().Contains(searchString.ToUpper())
                                     || s.Firstname.ToUpper().Contains(searchString.ToUpper())
                                     || s.Title.ToUpper().Contains(searchString.ToUpper())
                                     || s.Department.ToUpper().Contains(searchString.ToUpper())

                                     );
            }
            switch (sortOrder)
            {
                case "Name_desc":
                    users = users.OrderBy(s => s.Firstname);
                    break;
                case "Date":
                    users = users.OrderBy(s => s.BeginningOfLeave);
                    break;
                default:
                    users = users.OrderBy(s => s.Lastname);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(users.ToPagedList(pageNumber, pageSize));
        }


        public ActionResult SetStatus(int? id, string text)
        {
            var r = db.LeaveRequestForms.Find(id);
            if (r != null && text != null)
            {
                r.StatusHead = text;
                db.SaveChanges();
            }
            return RedirectToAction("Reservations");
        }


    }
}