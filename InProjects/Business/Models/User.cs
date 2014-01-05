using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InProjects.Business.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nickname { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Location { get; set; }

        public string Info { get; set; }

        public bool ShowMyProjects { get; set; }

        public bool ShowMySubscriptions { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}