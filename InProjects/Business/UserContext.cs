using InProjects.Business.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace InProjects.Business
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Project> Projects { get; set; }

        //public DbSet<Participant> Participants { get; set; }

        //public DbSet<ProjectSubscriber> ProjectSubscribers { get; set; }

        //public DbSet<VisibleUser> VisibilityList { get; set; }

        //public DbSet<BanUser> BlackList { get; set; }

        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Project>()
                .HasMany(p => p.Participants)
                .WithMany(u => u.Projects)
                .Map(m =>
                    {
                        m.ToTable("ProjectParticipants");
                        m.MapLeftKey("ProjectId");
                        m.MapRightKey("UserId");
                    });

            modelBuilder.Entity<Project>()
                .HasMany(p => p.Subscribers)
                .WithMany()
                .Map(m =>
                {
                    m.ToTable("ProjectSubscribers");
                    m.MapLeftKey("ProjectId");
                    m.MapRightKey("UserId");
                });

            modelBuilder.Entity<Project>()
                .HasMany(p => p.VisibilityList)
                .WithMany()
                .Map(m =>
                {
                    m.ToTable("ProjectVisibilityList");
                    m.MapLeftKey("ProjectId");
                    m.MapRightKey("UserId");
                });

            modelBuilder.Entity<Project>()
                .HasMany(p => p.BlackList)
                .WithMany()
                .Map(m =>
                {
                    m.ToTable("ProjectBlackList");
                    m.MapLeftKey("ProjectId");
                    m.MapRightKey("UserId");
                });
        } 
    }
}