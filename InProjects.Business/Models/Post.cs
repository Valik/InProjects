using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InProjects.Business.Models
{
    public abstract class Post
    {
        public int PostId { get; set;}
        [MaxLength(500)]
        public string Title { get; set; }
        [DataType(DataType.Url)]
        public object ResourceLink { get; set; }

        public string Body { get; set; }

        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public User Cretor { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}