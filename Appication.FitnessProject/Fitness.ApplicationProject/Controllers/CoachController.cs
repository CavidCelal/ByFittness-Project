using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fitness.ApplicationProject.Controllers
{
    [Authorize]
    public class CoachController : Controller
    {
        
        // GET: Coach
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ORnek()
        {
            return View();
        }
    }
}