using Microsoft.AspNetCore.Mvc;

namespace Test_task.Controllers
{
    public class InputController : Controller
    {
        public IActionResult Input() { return View(); }

        public IActionResult InputNameOfCategory(string nameOfCategory)
        {
            return RedirectToAction("Output", "Output", new { nameOfCategory });
        }
    }
}
