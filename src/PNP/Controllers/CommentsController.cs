using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using PNP.Models;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace PNP.Controllers
{
    [Authorize]
    public class CommentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //public IActionResult Index(int id)
        //{
        //    return View(_db.Comments.Where(comments => comments.StoryId == id).Include(comments => comments.Story).ToList());
        //}
        public IActionResult Details(int id)
        {
            var thisComment = db.Comments.FirstOrDefault(comments => comments.CommentId == id);
            return View(thisComment);
        }

        public ActionResult Create()
        {
            ViewBag.StoryId = new SelectList(db.Stories, "StoryId", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Comment item)
        {
            db.Comments.Add(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult ShowSpecificComments(int id)
        {
            var thisStory = (db.Comments.ToList());  //Where(c => c.StoryId == id));
            return View(thisStory);
        }
    }
}