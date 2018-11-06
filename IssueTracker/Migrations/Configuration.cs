namespace IssueTracker.Migrations
{
    using IssueTracker.Models;
    using IssueTracker.Services;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "IssueTracker.Models.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if(!context.Users.Any(t=>t.UserName=="admin@kanban.net"))
            {
                var user = new ApplicationUser { UserName = "admin@kanban.net", Email = "admin@kanban.net" };
                userManager.Create(user, "Password!2");

                var service = new UserAccountService(context);
                service.CreateUserAccount("admin", "adminson", user.Id);

                context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = "Admin" });
                context.SaveChanges(); // save changes to db to save role for following role asignment

                userManager.AddToRole(user.Id, "Admin");
                    
            }

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
