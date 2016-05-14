using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using PNP.Models;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Identity;
using System.Security.Claims;

namespace PNP.Controllers
{
    [Authorize]
    public class StoriesController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public StoriesController(
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext db
        )
        {
            _userManager = userManager;
            _db = db;
        }
        // GET Index
        public IActionResult Index()
        {
            return View(_db.Stories.ToList());
        }
        //GET Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Story story)
        {
            var currentUser = await _userManager.FindByIdAsync(User.GetUserId());
            _db.Stories.Add(story);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var thisStory = _db.Stories.FirstOrDefault(s => s.StoryId == id);
            return View(thisStory);
        }
        [HttpPost]
        public IActionResult Edit(Story story)
        {
            _db.Entry(story).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var thisStory = _db.Stories.FirstOrDefault(s => s.StoryId == id);
            return View(thisStory);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisStory = _db.Stories.FirstOrDefault(s => s.StoryId == id);
            _db.Stories.Remove(thisStory);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var thisStory = _db.Stories.FirstOrDefault(s => s.StoryId == id);
            return View(thisStory);
        }
        public IActionResult AddAComment(int id)
        {
            return View();
        }
        public IActionResult DisplayViewWithAjax()
        {
            return View();
        }
        public IActionResult ShowSpecificComments(int id)
        {
            var thisStory = (_db.Comments.Where(c => c.StoryId == id));
            return View(thisStory);
        }
    }
}
