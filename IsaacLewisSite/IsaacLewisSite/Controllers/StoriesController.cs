using IsaacLewisSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace IsaacLewisSite.Controllers
{
    public class StoriesController : Controller
    {
        ApplicationDbContext context;
        public StoriesController(ApplicationDbContext c)
        {
            context = c;
        }

        public IActionResult Index(int storyId)
        {
            var story = context.Stories
                .Include(story => story.User)
                .Where(story => story.StoryID == storyId)
                .SingleOrDefault();
            return View(story);
        }

        public IActionResult Story()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Story(Story model)
        {
            model.SubmitDate = DateTime.Now;
            context.Stories.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index", new { storyId = model.StoryID });
        }

    }
}
