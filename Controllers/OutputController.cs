using Microsoft.AspNetCore.Mvc;
using Test_task.Services;

namespace Test_task.Controllers
{
    public class OutputController : Controller
    {
        private readonly GetService _getService;

        public OutputController(GetService getService)
        {
            _getService = getService;
        }

        public async Task<IActionResult> Output(string nameOfCategory)
        {
            var outputObjects = await _getService.GetJoinedProductsAndCategories(nameOfCategory);

            return View(outputObjects);
        }
    }
}
