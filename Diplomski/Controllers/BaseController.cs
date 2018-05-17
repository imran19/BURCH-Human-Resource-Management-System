using Diplomski.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Diplomski.Controllers
{
    public class BaseController : Controller
    {
        protected DiplomskiContext db = new DiplomskiContext();
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            ViewData["user"] = db.Users.Find(Session["user_id"]);

        }
    }
}