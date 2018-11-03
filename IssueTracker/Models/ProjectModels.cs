using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IssueTracker.Models
{
    public class ProjectModels
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName="varchar")]
        [MinLength(10)]
        public string Description { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Name
        {
            get
            {
                return string.Format("{0}, {1}", this.FirstName, this.LastName);
            }
        }

        public virtual ApplicationUser OwnerUser { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        [Required]
        public string OwnerUserID { get; set; }
    }
}