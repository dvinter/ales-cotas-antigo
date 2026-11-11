using Microsoft.AspNetCore.Mvc;

namespace AlesCotas.MVC.Controllers.History
{
    public class HistoryController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("History");
        }
        public ActionResult History()
        {
            return View();
        }
        public IActionResult PostRedir()
        {
            return View("Views/History/Post/PostRedir.cshtml");
        }
    }
}
