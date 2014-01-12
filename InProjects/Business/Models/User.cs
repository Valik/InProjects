using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InProjects.Business.Models
{
    public class User
    {
        public User()
        {
            Projects = new HashSet<Project>();
            Tags = new HashSet<Tag>();
        }

        public int UserId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nickname { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Surname { get; set; }
        [MaxLength(200)]
        public string Location { get; set; }

        public string Info { get; set; }

        public bool ShowMyProjects { get; set; }

        public bool ShowMySubscriptions { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}