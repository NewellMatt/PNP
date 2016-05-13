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
        //private ApplicationDbContext db = new ApplicationDbContext();
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public CommentsController(
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext db
        )
        {
            _userManager = userManager;
            _db = db;
        }
        public IActionResult ShowSpecificComments(int id)
        {
            var thisStory = (_db.Comments.Where(c => c.StoryId == id));
            return View(thisStory);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Comment comment)
        {
            _db.Comments.Add(comment);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}