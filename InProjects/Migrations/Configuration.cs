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
        }

        protected override void Seed(InProjects.Business.UserContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var users = new List<User>
            {
                new User { Nickname = "Valik1", Name = "a1" },
                new User { Nickname = "Valik2", Name = "a2" },
                new User { Nickname = "Valik3", Name = "a3" },
                new User { Nickname = "Valik4", Name = "a4" },
                new User { Nickname = "Valik5", Name = "a5", Info = "asdfacda" },
            };

            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();

            var tags = new List<Tag>
            {
                new Tag { Name = "C#" },
                new Tag { Name = "Java" },
                new Tag { Name = "C++" },
                new Tag { Name = "Design" },
                new Tag { Name = "Ruby" }
            };

            tags.ForEach(t => context.Tags.Add(t));
            context.SaveChanges();
        }
    }
}
