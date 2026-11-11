using Microsoft.AspNetCore.Mvc;

namespace AlesCotas.MVC.Controllers.Extract
{
    public class ExtractController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Extract");
        }
        public IActionResult Extract()
        {
            return View();
        }
        public IActionResult ExtractList()
        {
            return View();
        }
        public IActionResult ExtractRequest()
        {
            return View();
        }
    }
}
