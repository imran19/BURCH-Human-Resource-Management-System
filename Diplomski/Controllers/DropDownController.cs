using Diplomski.Models;
using Diplomski.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Diplomski.Controllers
{
    public class DropDownController : Controller
    {
        // GET: DropDown
        public ActionResult Submit()
        {
            List<Country> allCountry = new List<Country>();
          //  List<State> allState = new List<State>();
            using (DiplomskiContext dc = new DiplomskiContext())
            {
                allCountry = dc.Countries.OrderBy(a => a.CountryName).ToList();
            }
            ViewBag.Id = new SelectList(allCountry, "Id", "CountryName");
            //ViewBag.StateID = new SelectList(allState, "StateID", "StateName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Submit (User fb)
        {
            List<Country> allCountry = new List<Country>();


            using (DiplomskiContext dc = new DiplomskiContext())
            {
                allCountry = dc.Countries.OrderBy(a => a.CountryName).ToList();
                //if( nt != null && nt.Id>0)
                //{
                    
                //}
            }
            ViewBag.Id = new SelectList(allCountry, "Id", "CountryName",fb.Id);

            if (ModelState.IsValid)
            {
                using (DiplomskiContext dc = new DiplomskiContext())
                {
                    dc.Users.Add(fb);
                    dc.SaveChanges();
                    ViewBag.Message = "Successfully submitted";
                }

         }
            else
            {
                ViewBag.Message = "Failed ! Please Try again.";
            }




            return View(fb);

        }
    }
}