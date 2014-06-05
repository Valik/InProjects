using System.ComponentModel.DataAnnotations;

namespace InProjects.Business.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        [Required]
        public RolesType RolesType { get; set; }
    }
}