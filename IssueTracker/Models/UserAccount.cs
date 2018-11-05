using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IssueTracker.Models
{
    public class UserAccount
    {
        public int Id { get; set; }

        public string ApplicationUserId {get; set;}

        [MinLength(3)]
        [MaxLength(255)]
        [Required]
        public string FirstName { get; set; }

        [MinLength(3)]
        [MaxLength(255)]
        [Required]
        public string LastName { get; set; }

        public virtual ICollection<ProjectModels> Projects { get; set; }

        public virtual ICollection<ProjectTask> Tasks { get; set; }

        public string Name
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }

        public string Initials
        {
            get
            {
                return (this.FirstName.Substring(0, 1) + this.LastName.Substring(0, 1));
            }
        }
    }
}