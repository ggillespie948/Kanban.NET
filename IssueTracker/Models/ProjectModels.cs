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
        [Column(TypeName = "varchar")]
        [MinLength(3)]
        public string Title { get; set; }

        [Required]
        [Column(TypeName="varchar")]
        [MinLength(10)]
        public string Description { get; set; }

        public string Name
        {
            get
            {
                return string.Format("{0} - Kanban Board", this.Title );
            }
        }

        public virtual ApplicationUser OwnerUser { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        [Required]
        public string OwnerUserID { get; set; }
    }
}