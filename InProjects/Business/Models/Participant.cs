using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InProjects.Business.Models
{
    public class Participant : ProjectUser
    {
        public string Position { get; set; }
    }
}