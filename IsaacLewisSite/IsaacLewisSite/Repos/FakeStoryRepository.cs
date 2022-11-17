using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IsaacLewisSite.Models;

namespace IsaacLewisSite.Repos
{
    public class FakeStoryRepository : IStoryRepository
    {
        List<Story> stories = new List<Story>();

        public IQueryable<Story> Stories
        {
            get { return stories.AsQueryable<Story>(); }
        }

        public void AddStory(Story story)
        {
            story.StoryID = stories.Count;
            stories.Add(story);
        }
    }
}
