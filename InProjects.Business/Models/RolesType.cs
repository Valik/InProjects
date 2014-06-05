using System;

namespace InProjects.Business.Models
{
    [Flags]
    public enum RolesType
    {
        User = 0x1,
        Editor = 0x2,
        Moderator = 0x4,
        Admin = User | Editor | Moderator
    }
}