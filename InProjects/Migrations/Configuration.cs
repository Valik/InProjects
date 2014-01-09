namespace InProjects.Migrations
{
    using InProjects.Business.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<InProjects.Business.UserContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(InProjects.Business.UserContext context)
        {
            var users = new List<User>
            {
                new User { Nickname = "Valik1", Name = "a1" },
                new User { Nickname = "Valik2", Name = "a2" },
                new User { Nickname = "Valik3", Name = "a3" },
                new User { Nickname = "Valik4", Name = "a4" },
                new User { Nickname = "Valik5", Name = "a5", Info = "asdfacda" },
            };

            var tags = new List<Tag>
            {
                new Tag { Name = "C#" },
                new Tag { Name = "Java" },
                new Tag { Name = "C++" },
                new Tag { Name = "Design" },
                new Tag { Name = "Ruby" }
            };

            var projects = new List<Project>
            {
                new Project { Name = "pr1", Creator = users[0]},
                new Project { Name = "pr2", Creator = users[1]},
                new Project { Name = "pr3", Creator = users[2]},
            };

            projects[0].Tags.Add(tags[0]);
            projects[0].Tags.Add(tags[1]);

            projects[1].BlackList.Add(users[2]);
            projects[1].BlackList.Add(users[3]);

            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();

            tags.ForEach(t => context.Tags.Add(t));
            context.SaveChanges();

            projects.ForEach(p => context.Projects.Add(p));
            context.SaveChanges();
        }
    }
}
