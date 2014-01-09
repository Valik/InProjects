using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InProjects.Business.Models
{
    public class Tag
    {
        public int TagId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}