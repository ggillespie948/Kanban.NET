using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace IssueTracker.Models
{
    public interface IApplicationDbContext
    {
        IDbSet<UserAccount> UserAccounts { get; set; }
        IDbSet<ProjectModels> ProjectModels { get; set; }
        IDbSet<ProjectTask> ProjectTasks { get; set; }
        IDbSet<ApplicationUser> Users { get; set; }
        int SaveChanges();
        void Dispose();
        
        DbEntityEntry Entry(object entry);
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public IDbSet<UserAccount> UserAccounts { get; set; }
        public IDbSet<ProjectModels> ProjectModels { get; set; }
        public IDbSet<ProjectTask> ProjectTasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAccount>().Property(t => t.FirstName).IsRequired();
            modelBuilder.Entity<UserAccount>().Property(t => t.LastName).IsRequired();
            modelBuilder.Entity<ProjectTask>().Property(t => t.ProjectID).IsRequired();
            base.OnModelCreating(modelBuilder);
        }

    }

    public class MockedApplicationDbContext : IApplicationDbContext
    {
        public IDbSet<UserAccount> UserAccounts { get; set; }
        public IDbSet<ProjectModels> ProjectModels { get; set; }
        public IDbSet<ProjectTask> ProjectTasks { get; set; }
        public IDbSet<ApplicationUser> Users { get; set; }

        public int SaveChanges()
        { 
            return 0;
        }

        public void Dispose()
        {
            return;
        }

        public DbEntityEntry Entry(object entry)
        {
            return (DbEntityEntry)entry;
        }

        

    }
}