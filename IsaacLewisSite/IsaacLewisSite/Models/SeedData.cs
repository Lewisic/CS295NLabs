using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsaacLewisSite.Models
{
    public class SeedData
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.Stories.Any())
            {
                AppUser isaac = new AppUser() { UserName = "Isaac Lewis" };
                context.AppUsers.Add(isaac);
                context.SaveChanges();

                Story story = new Story
                {
                    StoryTitle = "Rogue One",
                    StoryTopic = "Death Star Plans",
                    StoryDate = 0,
                    StoryText = "A group of rebels steal the death star plans",
                    User = isaac,
                    SubmitDate = DateTime.Parse("11/2/2022")
                };
                context.Stories.Add(story);

                story = new Story
                {
                    StoryTitle = "Revenge of the Sith",
                    StoryTopic = "The fall of the jedi",
                    StoryDate = -18,
                    StoryText = "The fall of Anakin Skywalker",
                    User = isaac,
                    SubmitDate = DateTime.Parse("11/3/2022")
                };
                context.Stories.Add(story);

                story = new Story
                {
                    StoryTitle = "A New Hope",
                    StoryTopic = "A new hope has appeared",
                    StoryDate = 0,
                    StoryText = "The start of Lukes journey",
                    User = new AppUser { UserName = "Luke Skywalker"},
                    SubmitDate = DateTime.Parse("11/16/2022")
                };
                context.Stories.Add(story);

                context.SaveChanges();
            }
        }
    }
}
