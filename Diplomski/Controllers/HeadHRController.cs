using Diplomski.Models;
using Diplomski.Scripts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;


using System.Net.Mail;

namespace Diplomski.Controllers
{
    public class HeadHRController : BaseController
    {


        // GET: User
        public ViewResult ListOfUsers(string sortOrder, string currentFilter, string searchString, int? page)
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


            var users = from s in db.Users
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(s => s.Lastname.ToUpper().Contains(searchString.ToUpper())
                                     || s.Firstname.ToUpper().Contains(searchString.ToUpper())
                                     || s.Title.ToUpper().Contains(searchString.ToUpper())
                                     || s.CountryName.ToUpper().Contains(searchString.ToUpper())
                                     || s.Department.ToUpper().Contains(searchString.ToUpper())
                                     || s.Faculty.ToUpper().Contains(searchString.ToUpper())   
                                     || s.ElectoralPeriod.ToUpper().Contains(searchString.ToUpper())                          
                                     );
            }
            switch (sortOrder)
            {
                case "Name_desc":
                    users = users.OrderBy(s => s.Firstname);
                    break;
                case "Date":
                    users = users.OrderBy(s => s.ContractExpiration);
                    break;
                default:
                    users = users.OrderBy(s => s.Lastname);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(users.ToPagedList(pageNumber, pageSize));
        }

        //public ActionResult ListOfUsers(string search)
        //{
        //    var usr = db.Users;
        //    List<User> users;

        //    if (!String.IsNullOrEmpty(search))
        //    {
        //        users = usr.Where(s =>
        //            s.Firstname.Contains(search) ||
        //            s.Lastname.Contains(search))
        //            .ToList();
        //    }
        //    else
        //    {
        //        users = usr.ToList();
        //    }
        //    return View(users);
        //}






        public ActionResult RegisterUser()
        {

            List<Country> allCountry = new List<Country>();
            List<Department> allDepartments = new List<Department>();
            List<Faculty> allFaculty = new List<Faculty>();
            List<Title> allTitle = new List<Title>();
            List<ElectoralPeriod> allElectoralPeriod = new List<ElectoralPeriod>();
            List<Stay> allStays = new List<Stay>();
            List<EmploymentStatus> allEmploymentStatuses = new List<EmploymentStatus>();
            //  List<State> allState = new List<State>();
            //using (DiplomskiContext dc = new DiplomskiContext())
            //  {
            allCountry = db.Countries.OrderBy(a => a.CountryName).ToList();
            allDepartments = db.Departments.OrderBy(a => a.DepartmentName).ToList();
            allFaculty = db.Faculties.OrderBy(a => a.FacultyName).ToList();
            allTitle = db.Titles.OrderBy(a => a.TitleName).ToList();
            allElectoralPeriod = db.ElectoralPeriods.OrderBy(a => a.ElectoralPeriodName).ToList();
            allStays = db.Stays.OrderBy(a => a.StayName).ToList();
            allEmploymentStatuses = db.EmploymentStatuses.OrderBy(a => a.EmploymentName).ToList();
            //  }
            ViewBag.CountryName = new SelectList(allCountry,"CountryName", "CountryName");
            ViewBag.DepartmentName = new SelectList(allDepartments, "DepartmentName", "DepartmentName");
            ViewBag.FacultyName = new SelectList(allFaculty, "FacultyName", "FacultyName");
            ViewBag.TitleName = new SelectList(allTitle, "TitleName", "TitleName");
            ViewBag.ElectoralPeriodName = new SelectList(allElectoralPeriod, "ElectoralPeriodName", "ElectoralPeriodName");
            ViewBag.StayName = new SelectList(allStays, "StayName", "StayName");
            ViewBag.EmploymentName = new SelectList(allEmploymentStatuses, "EmploymentName", "EmploymentName");
            return View( new User());
        }



        [HttpPost]
        public ActionResult RegisterUser(User user)
        {

            List<Country> allCountry = new List<Country>();
            allCountry = db.Countries.OrderBy(a => a.CountryName).ToList();
            ViewBag.CountryName = new SelectList(allCountry, "CountryName", "CountryName", user.CountryName);

            List<Department> allDepartments = new List<Department>();
            allDepartments = db.Departments.OrderBy(a => a.DepartmentName).ToList();
            ViewBag.DepartmentName = new SelectList(allDepartments, "DepartmentName", "DepartmentName", user.Department);


            List<Faculty> allFaculty = new List<Faculty>();
            allFaculty = db.Faculties.OrderBy(a => a.FacultyName).ToList();
            ViewBag.FacultyName = new SelectList(allFaculty, "FacultyName", "FacultyName", user.Faculty);

            List<Title> allTitle = new List<Title>();
           allTitle = db.Titles.OrderBy(a => a.TitleName).ToList();
            ViewBag.TitleName = new SelectList(allTitle, "TitleName", "TitleName", user.Title);

            List<ElectoralPeriod> allElectoralPeriod = new List<ElectoralPeriod>();
               allElectoralPeriod = db.ElectoralPeriods.OrderBy(a => a.ElectoralPeriodName).ToList();
            ViewBag.ElectoralPeriodName = new SelectList(allElectoralPeriod, "ElectoralPeriodName", "ElectoralPeriodName", user.ElectoralPeriod);

            List<Stay> allStays = new List<Stay>();
            allStays = db.Stays.OrderBy(a => a.StayName).ToList();
            ViewBag.StayName = new SelectList(allStays, "StayName", "StayName",user.Stay);

            List<EmploymentStatus> allEmploymentStatuses = new List<EmploymentStatus>();
            allEmploymentStatuses = db.EmploymentStatuses.OrderBy(a => a.EmploymentName).ToList();
            ViewBag.EmploymentName = new SelectList(allEmploymentStatuses, "EmploymentName", "EmploymentName",user.EmploymentStatus);

            if (Request.Files.Count > 0)
            {
                user.Image = new BinaryReader(Request.Files[0].InputStream).ReadBytes(Request.Files[0].ContentLength);
            }
   
            if (ModelState.IsValid)
            {
                //List<Nationality> allNationalities = new List<Nationality>();
                    //allNationalities = db.Nationalities.OrderBy(a => a.CountryName).ToList();
                    //ViewBag.Departments = new SelectList(db.Departments, "Id", "DepartmentName");
                    user = db.Users.Add(user);
                    db.SaveChanges();
                    //  ViewBag.Message = "Successfully submitted";
                    //Session["user_id"] = account.Id;
                    return RedirectToAction("ListOfUsers");
                }
            return View();
            //ModelState.Clear();
            //ViewBag.Message = "Successfully Created User Account";
            //// ViewBag.Message = account.Firstname + "Successfully registered.";
            //return RedirectToAction("ListOfUsers");



        }

        public ActionResult HrEditUser(int id)
        {
            
            List<Country> allCountry = new List<Country>();
            List<Department> allDepartments = new List<Department>();
            List<Faculty> allFaculty = new List<Faculty>();
            List<Title> allTitle = new List<Title>();
            List<ElectoralPeriod> allElectoralPeriod = new List<ElectoralPeriod>();
            List<Stay> allStays = new List<Stay>();
            List<EmploymentStatus> allEmploymentStatuses = new List<EmploymentStatus>();
            //  List<State> allState = new List<State>();
            //using (DiplomskiContext dc = new DiplomskiContext())
            //  {
            allCountry = db.Countries.OrderBy(a => a.CountryName).ToList();
            allDepartments = db.Departments.OrderBy(a => a.DepartmentName).ToList();
            allFaculty = db.Faculties.OrderBy(a => a.FacultyName).ToList();
            allTitle = db.Titles.OrderBy(a => a.TitleName).ToList();
            allElectoralPeriod = db.ElectoralPeriods.OrderBy(a => a.ElectoralPeriodName).ToList();
            allStays = db.Stays.OrderBy(a => a.StayName).ToList();
            allEmploymentStatuses = db.EmploymentStatuses.OrderBy(a => a.EmploymentName).ToList();
            //  }
            ViewBag.CountryName = new SelectList(allCountry,"CountryName", "CountryName");
            ViewBag.DepartmentName = new SelectList(allDepartments, "DepartmentName", "DepartmentName");
            ViewBag.FacultyName = new SelectList(allFaculty, "FacultyName", "FacultyName");
            ViewBag.TitleName = new SelectList(allTitle, "TitleName", "TitleName");
            ViewBag.ElectoralPeriodName = new SelectList(allElectoralPeriod, "ElectoralPeriodName", "ElectoralPeriodName");
            ViewBag.StayName = new SelectList(allStays, "StayName", "StayName");
            ViewBag.EmploymentName = new SelectList(allEmploymentStatuses, "EmploymentName", "EmploymentName");

            return View("HrEditUser", db.Users.Find(id));
        }

        [HttpPost]
        public ActionResult HrEdituser(User user)
        {
            if (ModelState.IsValid)
            {
                User s = db.Users.Find(user.Id);

                if (Request.Files.Count > 0)
                {
                    s.Image = new BinaryReader(Request.Files[0].InputStream).ReadBytes(Request.Files[0].ContentLength);
                }
                s.Firstname = user.Firstname;
                s.Lastname = user.Lastname;
                s.EmployeeRegNum = user.EmployeeRegNum;
                s.Email = user.Email;
                s.Phone = user.Phone;
                s.Address = user.Address;
                s.Title = user.Title;
                s.Faculty = user.Faculty;
                s.Department = user.Department;
                s.EmploymentStatus = user.EmploymentStatus;
                s.CountryName = user.CountryName;
                s.DateOfBirth = user.DateOfBirth;
                s.ElectoralPeriod = user.ElectoralPeriod;
                s.ContractExpiration = user.ContractExpiration;
                s.NumberOfLeaveDays = user.NumberOfLeaveDays;
                s.Stay = user.Stay;
                s.Password = user.Password;
                s.ConfirmPassword = user.ConfirmPassword;
                s.ChiefHRManager = user.ChiefHRManager;
                s.HeadOfDep = user.HeadOfDep;
                s.Dean = s.Dean;
                s.OrdinaryHRManager = s.OrdinaryHRManager;



                db.SaveChanges();
                return RedirectToAction("ListOfUsers");
            }
            return View(user);
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User users = db.Users.Find(id);


            if (users == null)
            {
                return HttpNotFound();
            }

            return View(users);
        }


        public ActionResult DeleteUser(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            if (user == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("ListOfUsers");
        }

        public ActionResult HRMHome()
        {
            return View();
        }

        public ActionResult Edit()
        {
            int? user_id = Session["user_id"] as int?;

            if (user_id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(user_id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                User toSave = db.Users.Find(user.Id);
                db.Entry(toSave).CurrentValues.SetValues(user);
                toSave.ChiefHRManager = user.ChiefHRManager;
                db.SaveChanges();
                return RedirectToAction("HRMHome");
            }

            return View(user);
        }









        //public ActionResult Edit()
        //{
        //    int? user_id = Session["user_id"] as int?;

        //    if (user_id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    User user = db.Users.Find(user_id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        User toSave = db.Users.Find(user.Id);
        //        db.Entry(toSave).CurrentValues.SetValues(user);
        //        toSave.ChiefHRManager = user.ChiefHRManager;
        //        db.SaveChanges();
        //        return RedirectToAction("ListOfUsers");
        //    }

        //    return View(user);
        //}

        //public ActionResult EditUser(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    User user = db.Users.Find(id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult EditUser([Bind(Include = "Id,Firstname,Lastname,EmployeeRegNum,Email,Phone,Address,Title,Faculty,Department,EmploymentStatus,Country,DateOfBirth,ElectoralPeriod,ContractExpiration,NumberOfLeaveDays,Stay,Password,ConfirmPassword,ChiefHRManager")] User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        User toSave = db.Users.Find(user.Id);
        //        db.Entry(toSave).CurrentValues.SetValues(user);
        //        db.Entry(toSave).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("ListOfUsers");
        //    }
        //    return View(user);
        //}


    }

}