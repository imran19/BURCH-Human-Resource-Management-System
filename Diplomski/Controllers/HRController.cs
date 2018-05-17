using Diplomski.Models;
using Diplomski.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Diplomski.Controllers
{
    public class HRController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult RegisterUser()
        {
          //  ViewBag.Nationality();
            return View();
        }


        [HttpPost]
        public ActionResult RegisterUser(User account)
        {
            if (ModelState.IsValid)
            {
                List<Country> allNationalities = new List<Country>();
                using (DiplomskiContext db = new DiplomskiContext())

                {
                    //allNationalities = db.Nationalities.OrderBy(a => a.CountryName).ToList();
                  
              
                    ViewBag.Departments = new SelectList(db.Departments, "Id", "DepartmentName");

                    account = db.Users.Add(account);
                    db.SaveChanges();
                    
                    //Session["user_id"] = account.Id;
                }

                ModelState.Clear();
                ViewBag.Message = "Successfully Created User Account";
                // ViewBag.Message = account.Firstname + "Successfully registered.";
                return RedirectToAction("RegisterUser");
            }
            
            return View();
        }










    }






}