using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using PNP.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace PNP.Controllers
{
    public class StoriesController : Controller
    {
        private PNPContext db = new PNPContext();
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
    }
}
