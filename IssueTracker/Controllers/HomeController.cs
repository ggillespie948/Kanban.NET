using IssueTracker.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IssueTracker.Controllers
{
    public class HomeController : Controller
    {

        private IApplicationDbContext db;

        public HomeController()
        {
            db = new ApplicationDbContext();
        }

        public HomeController(IApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        [Authorize]
        public ActionResult Index()
        {
            //var userId = User.Identity.GetUserId();
            //var currentAccountId = db.Users.Where(c => c.Id == userId).First().Id;
            //ViewBag.CurrentAccountId = currentAccountId;
            return View();
        }

        [Route("About")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}