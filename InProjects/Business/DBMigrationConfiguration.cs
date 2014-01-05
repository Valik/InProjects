using InProjects.Business.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InProjects.Business
{
    public class DBInitializercs : DropCreateDatabaseIfModelChanges<UserContext>
    {
        protected override void Seed(UserContext context)
        {
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