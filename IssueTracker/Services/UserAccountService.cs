using IssueTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IssueTracker.Services
{
    public class UserAccountService
    {
        private ApplicationDbContext db;

        public UserAccountService(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        public void CreateUserAccount(string firstName, string lastName, string userId)
        {
            //Create new User Accont instance and link to ApplictionUser
            var userAccount = new UserAccount { FirstName = firstName, LastName = lastName, ApplicationUserId = userId };
            db.UserAccounts.Add(userAccount);
            db.SaveChanges();
        }
    }
}