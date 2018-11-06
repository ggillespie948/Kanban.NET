using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IssueTracker.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace IssueTracker.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProjectModels

        public ActionResult Index()
        {
            var projectModels = db.ProjectModels.Include(p => p.OwnerUser);
            return View(projectModels.ToList());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ListAllAdmin()
        {
            return View(db.ProjectModels.ToList());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DetailsForAdmin(int id)
        {
            ProjectModels projectModels = db.ProjectModels.Find(id);
            if (projectModels == null)
            {
                return HttpNotFound();
            }
            
            //Project Member Authenticated, serving View
            return View("Details", projectModels);
        }

        // GET: ProjectModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectModels projectModels = db.ProjectModels.Find(id);
            if (projectModels == null)
            {
                return HttpNotFound();
            }

            //Authorise this method to ensure the logged in user is either an owner or at least a member fot he current project
            var userId = User.Identity.GetUserId();
            bool isProjectMember = false;

            if(projectModels.OwnerUserID != userId)
            {
                //user is not the project owner - search related team members
                foreach(UserAccount userAcc in projectModels.ProjectMembers)
                {
                    if(userAcc.ApplicationUserId == userId)
                    {
                        isProjectMember = true;
                        break;
                    }
                }
                if(!isProjectMember)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }

            //Project Member Authenticated, serving View
            return View(projectModels);
        }

        // GET: ProjectModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,Title,Description,ApplicationUserId,OwnerUserID")] ProjectModels projectModels)
        {
            var userId = User.Identity.GetUserId();
            //ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            projectModels.ApplicationUserId = userId;
            projectModels.OwnerUserID = userId;
            projectModels.OwnerUser = db.Users.Where(u => u.Id == userId).FirstOrDefault();
            projectModels.ProjectMembers.Add(db.UserAccounts.Where(u => u.ApplicationUserId == userId).FirstOrDefault());

           db.ProjectModels.Add(projectModels);
           db.SaveChanges();
           

           return RedirectToAction("Index");
        }

        // GET: ProjectModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectModels projectModels = db.ProjectModels.Find(id);
            if (projectModels == null)
            {
                return HttpNotFound();
            }
            //ViewBag.OwnerUserID = new SelectList(db.ApplicationUsers, "Id", "Email", projectModels.OwnerUserID);
            return View(projectModels);
        }

        // POST: ProjectModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,FirstName,LastName,ApplicationUserId,OwnerUserID")] ProjectModels projectModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.OwnerUserID = new SelectList(db.ApplicationUsers, "Id", "Email", projectModels.OwnerUserID);
            return View(projectModels);
        }

        // GET: ProjectModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectModels projectModels = db.ProjectModels.Find(id);
            if (projectModels == null)
            {
                return HttpNotFound();
            }
            return View(projectModels);
        }

        // POST: ProjectModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectModels projectModels = db.ProjectModels.Find(id);
            db.ProjectModels.Remove(projectModels);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
