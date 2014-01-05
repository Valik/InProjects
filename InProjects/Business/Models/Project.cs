using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InProjects.Business.Models
{
    public class Project
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Info { get; set; }

        public string Image { get; set; }

        public string Logo { get; set; }

        public bool UseLogo { get; set; }

        public int UserId { get; set; }

        public Scope VisibilityScope { get; set; }

        public Scope CommentScope { get; set; }

        public int HideCommentRating { get; set; }

        public virtual ICollection<Participant> Participants { get; set; }

        public virtual ICollection<ProjectSubscriber> Subscribers { get; set; }

        public virtual ICollection<VisibleUser> VisibilityList { get; set; }

        public virtual ICollection<BanUser> BlackList { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}