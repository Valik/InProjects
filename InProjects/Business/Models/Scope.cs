using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InProjects.Business.Models
{
    [Flags]
    public enum Scope
    {
        Participants = 0,
        Registered = 1,
        ByList = 2,
        All = 4,
    }
}