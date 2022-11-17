using IsaacLewisSite.Models;
using IsaacLewisSite.Controllers;
using IsaacLewisSite.Repos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO.MemoryMappedFiles;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace Tests
{
    public class StoriesTests
    {
        [Fact]
        public void AddStoryTest()
        {
            var fakeRepo = new FakeStoryRepository();
            var controller = new StoriesController(fakeRepo);
            var story = new Story()
            {
                StoryTitle = "Testing1",
                StoryTopic = "Really good testing",
                StoryDate = 1000,
                StoryText = "The epic story of testing",
                User = new AppUser() { UserName = "Isaac Lewis" }
            };

            controller.Story(story);

            var retrievedItem = fakeRepo.Stories.ToList()[0];
            Assert.Equal(retrievedItem.StoryTitle, "Testing1");
        }

        [Fact]
        public async void StoryTitleFilterTest()
        {
            var fakeRepo = new FakeStoryRepository();
            var controller = new StoriesController(fakeRepo);
            var story = new Story()
            {
                StoryTitle = "Testing1",
                StoryTopic = "Really good testing",
                StoryDate = 1000,
                StoryText = "The epic story of testing",
                User = new AppUser() { UserName = "Isaac Lewis" }
            };

            controller.Story(story);

            story = new Story()
            {
                StoryTitle = "Testing2",
                StoryTopic = "Really good testing",
                StoryDate = 1000,
                StoryText = "The epic story of testing",
                User = new AppUser() { UserName = "Isaac Lewis" }
            };
            controller.Story(story);

            story = new Story()
            {
                StoryTitle = "Testing3",
                StoryTopic = "Really good testing",
                StoryDate = 1000,
                StoryText = "The epic story of testing",
                User = new AppUser() { UserName = "Randomer" }
            };
            controller.Story(story);

            var viewResult = (ViewResult)controller.Index("Testing1", null);

            var stories = (List<Story>)viewResult.ViewData.Model;

            Assert.Equal(1, stories.Count);
            Assert.Equal(stories[0].StoryTitle, "Testing1");
        }

        [Fact]
        public async void StoryUserNameFilterTest()
        {
            var fakeRepo = new FakeStoryRepository();
            var controller = new StoriesController(fakeRepo);
            var story = new Story()
            {
                StoryTitle = "Testing1",
                StoryTopic = "Really good testing",
                StoryDate = 1000,
                StoryText = "The epic story of testing",
                User = new AppUser() { UserName = "Isaac Lewis" }
            };

            controller.Story(story);

            story = new Story()
            {
                StoryTitle = "Testing2",
                StoryTopic = "Really good testing",
                StoryDate = 1000,
                StoryText = "The epic story of testing",
                User = new AppUser() { UserName = "Isaac Lewis" }
            };
            controller.Story(story);

            story = new Story()
            {
                StoryTitle = "Testing3",
                StoryTopic = "Really good testing",
                StoryDate = 1000,
                StoryText = "The epic story of testing",
                User = new AppUser() { UserName = "Randomer" }
            };
            controller.Story(story);

            var viewResult = (ViewResult)controller.Index(null, "Isaac Lewis");

            var stories = (List<Story>)viewResult.ViewData.Model;

            Assert.Equal(2, stories.Count);
            Assert.Equal(stories[0].StoryTitle, "Testing1");
            Assert.Equal(stories[0].User.UserName, "Isaac Lewis");
        }
    }
}
