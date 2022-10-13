using IsaacLewisSite.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IsaacLewisSite.Controllers
{
    public class StoriesController : Controller
    {
        public IActionResult Index(string storyTitle, string storyTopic, int storyDate, string storyAuthor, string storyText, DateTime date)
        {
            Story story = new Story();
            story.StoryTitle = storyTitle;
            story.StoryTopic = storyTopic;
            story.StoryDate = storyDate;
            AppUser user = new AppUser();
            user.UserName = storyAuthor;
            story.StoryText = storyText;
            story.SubmitDate = date;
            story.User = user;
            return View(story);
        }

        public IActionResult Story()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Story(Story model)
        {
            return RedirectToAction("Index",
                    new
                    {
                        storyTitle = model.StoryTitle,
                        storyTopic = model.StoryTopic,
                        storyDate = model.StoryDate,
                        storyAuthor = model.User.UserName,
                        storyText = model.StoryText,
                        date = DateTime.Now
                    }
                );
        }

    }
}
