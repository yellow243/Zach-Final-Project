using Microsoft.AspNetCore.Mvc;

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
            var products = repo.GetAllGods();
            return View(products);
        }

        public IActionResult ViewGod(int id)
        {
            var product = repo.GetGod(id);
            return View(product);
        }

    }
}
