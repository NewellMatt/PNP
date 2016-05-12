using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using PNP.Models;

namespace PNP.Controllers
{
    public class CommentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public IActionResult Index()
        {//we want to include each comments story
            return View(db.Comments.Include(c => c.Story).ToList());
        }
        public IActionResult ShowSpecificComments(int id)
        {
            var thisStory = (db.Comments.Where(c => c.StoryId == id));
            return View(thisStory);
        }
    }
}