using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InProjects.Business.Models
{
    public class User
    {
        public User()
        {
            Projects = new HashSet<Project>();
            Tags = new HashSet<Tag>();
            Subscribers = new HashSet<User>();
        }

        public int UserId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nickname { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
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

        public virtual ICollection<User> Subscribers { get; set; }
    }
}