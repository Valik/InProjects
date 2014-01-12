using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InProjects.Business.Models
{
    public class Project
    {
        private Object lockObject = new object();
        private volatile User creator;

        public Project()
        {
            Participants = new HashSet<User>();
            VisibilityList = new HashSet<User>();
            BlackList = new HashSet<User>();
            Tags = new HashSet<Tag>();
        }

        public int ProjectId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public string Info { get; set; }

        public string Image { get; set; }

        public string Logo { get; set; }

        public bool UseLogo { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; }

        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public User Creator 
        {
            get { return creator; }
            set 
            {
                lock (lockObject)
                {
                    creator = value;
                    #warning Need to implement custom check of containing user.
                    if (Participants.Contains(creator))
                    {
                        Participants.Remove(creator);
                    }

                    Participants.Add(creator);
                }

            }
        }

        public Scope VisibilityScope { get; set; }

        public Scope CommentScope { get; set; }

        public int HideCommentRating { get; set; }

        public virtual ICollection<User> Participants { get; set; }

        public virtual ICollection<User> Subscribers { get; set; }

        public virtual ICollection<User> VisibilityList { get; set; }

        public virtual ICollection<User> BlackList { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}