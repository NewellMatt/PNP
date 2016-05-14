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
        public IActionResult Index(int id)
        {
            return View(_db.Comments.Where(comments => comments.StoryId == id).Include(comments => comments.Story).ToList());
        }
        public IActionResult Details(int id)
        {
            var thisComment = _db.Comments.FirstOrDefault(comments => comments.CommentId == id);
            return View(thisComment);
        }

        public IActionResult Create(int id)
        {
            ViewBag.StoryId = id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Comment comment)
        {
            var id = comment.StoryId;
            var currentUser = await _userManager.FindByIdAsync(User.GetUserId());
            _db.Comments.Add(comment);
            _db.SaveChanges();
            return RedirectToAction("Index", "Stories");
        }

        public IActionResult ShowSpecificComments(int id)
        {
            var thisStory = (_db.Comments.Where(c => c.StoryId == id));
            return View(thisStory);
        }
    }
}