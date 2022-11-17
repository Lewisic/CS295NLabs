using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IsaacLewisSite.Models;

namespace IsaacLewisSite.Repos
{
    public class StoryRepository : IStoryRepository
    {
        private ApplicationDbContext context;

        public StoryRepository(ApplicationDbContext c)
        {
            context = c;
        }

        public IQueryable<Story> Stories
        {
            get
            {
                return context.Stories.Include(story => story.User);
            }
        }

        public void AddStory(Story story)
        {
            context.Stories.Add(story);
            context.SaveChanges();
        }
    }
}
