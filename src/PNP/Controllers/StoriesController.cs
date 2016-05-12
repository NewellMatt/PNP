using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using PNP.Models;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace PNP.Controllers
{
    [Authorize]
    public class StoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public IActionResult Index()
        {
            return View(db.Stories.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Story item)
        {
            db.Stories.Add(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var thisStory = db.Stories.FirstOrDefault(s => s.StoryId == id);
            return View(thisStory);
        }
        [HttpPost]
        public IActionResult Edit(Story story)
        {
            db.Entry(story).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var thisStory = db.Stories.FirstOrDefault(s => s.StoryId == id);
            return View(thisStory);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisStory = db.Stories.FirstOrDefault(s => s.StoryId == id);
            db.Stories.Remove(thisStory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var thisStory = db.Stories.FirstOrDefault(s => s.StoryId == id);
            return View(thisStory);
        }
        public IActionResult AddAComment(int id)
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult AddAComment(Comment item)
        //{
        //    db.Comments.Add(item);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}
