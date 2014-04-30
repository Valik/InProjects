using System;

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