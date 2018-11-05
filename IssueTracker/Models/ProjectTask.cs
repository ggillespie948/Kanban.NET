﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;

namespace IssueTracker.Models
{
    public class ProjectTask
    {
        public ProjectTask()
        {
            Members = new HashSet<ApplicationUser>();
        }
        public int Id { get; set; }

        [Required]
        public int ProjectID;

        [Required]
        public int CreatorId { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }

        public int Complexity { get; set;  }

        [Required]
        [MinLength(3)]
        public string Description { get; set; }

        public ICollection<string> Comments { get; set; }

        public ICollection<ApplicationUser> Members { get; set; }



        
    }
}