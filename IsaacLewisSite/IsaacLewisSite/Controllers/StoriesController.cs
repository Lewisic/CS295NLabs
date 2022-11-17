using IsaacLewisSite.Models;
using IsaacLewisSite.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IsaacLewisSite.Controllers
{
    public class StoriesController : Controller
    {
        IStoryRepository repo;
        public StoriesController(IStoryRepository r)
        {
            repo = r;
        }

        public IActionResult Index()
        {
            List<Story> stories = repo.Stories.ToList<Story>();
            return View(stories);
        }

        [HttpPost]
        public IActionResult Index(string storyTitle, string userName)
        {
            List<Story> stories = null;

            if (storyTitle != null)
            {
                stories = (from r in repo.Stories where r.StoryTitle == storyTitle select r).ToList();
            }
            else if (userName != null)
            {
                stories = (from r in repo.Stories where r.User.UserName == userName select r).ToList();
            }

            return View(stories);
        }

        public IActionResult Story()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Story(Story model)
        {
            model.SubmitDate = DateTime.Now.Date;
            repo.AddStory(model);
            return View(model);
        }

    }
}
