using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace InProjects.Business.Models
{
    public class Comment
    {
        public int CommentId { get; set; }

        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public User Creator { get; set; }

        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public Post Post { get; set; }

        public int? RelatedCommentId { get; set; }
        [ForeignKey("RelatedCommentId")]
        public Comment RelatedComment { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; }

        public string Body { get; set; }
        
        public int RaitingPlus { get; set; }

        public int RaitngMinus { get; set; }

        public bool IsHat { get; set; }
    }
}