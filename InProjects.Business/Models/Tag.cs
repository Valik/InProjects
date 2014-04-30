using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InProjects.Business.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}