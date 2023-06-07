using Microsoft.AspNetCore.Mvc;
using Zach_Final_Project.Models;

namespace Zach_Final_Project.Controllers
{
    public class GodController : Controller
    {
        private readonly IGodRepository repo;

        public GodController(IGodRepository repo)
        {
            this.repo = repo;
        }

        //Get: Controller
        public IActionResult Index()
        {
            var gods = repo.GetAllGods();
            return View(gods);
        }

        public IActionResult ViewGod(int id)
        {
            var god = repo.GetGod(id);
            return View(god);
        }

        public IActionResult UpdateGod(int id)
        {
            God god = repo.GetGod(id);
            if (god == null)
            {
                return View("GodNotFound");
            }
            return View(god);
        }

        public IActionResult UpdateGodToDatabase(God god)
        {
            repo.UpdateGod(god);

            return RedirectToAction("ViewGod", new { id = god.GodID });
        }

        public IActionResult InsertGod()
        {
            
            return View(new God());
        }

        public IActionResult InsertGodToDatabase(God godToInsert)
        {
            repo.InsertGod(godToInsert);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteGod(God god)
        {
            repo.DeleteGod(god);
            return RedirectToAction("Index");
        }
    }
}
