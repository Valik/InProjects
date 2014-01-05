﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InProjects.Business.Models
{
    public abstract class ProjectUser
    {
        public int Id { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }

        public Project Project { get; set; }

        public int ProjectId { get; set; }
    }
}