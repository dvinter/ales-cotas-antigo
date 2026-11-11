using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlesCotas.MVC.Controllers.Requests.Daily
{
    [Authorize]
    public class DailyController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Requests", null);
        }
        public IActionResult ListRequestDaily()
        {
            return View("Views/Requests/Daily/ListRequestDaily.cshtml");
        }
        public IActionResult DailyApproved()
        {
            return View("Views/Requests/Daily/DailyApproved.cshtml");
        }
        public ActionResult FormDailyOne(int? id)
        {
            return View("Views/Requests/Daily/FormDailyOne.cshtml");
        }
        public ActionResult FormDailyTwo(int? id)
        {
            return View("Views/Requests/Daily/FormDailyTwo.cshtml");
        }
        public ActionResult FormDailyThree(int? id)
        {
            return View("Views/Requests/Daily/FormDailyThree.cshtml");
        }
        public ActionResult FormDailyFour(int? id)
        {
            return View("Views/Requests/Daily/FormDailyFour.cshtml");
        }
         public ActionResult DailyHistory()
        {
            return View("Views/History/Daily/DailyHistory.cshtml");
        }
        public ActionResult DailyHistoryDetail(int id)
        {
            return View("Views/History/Daily/DailyHistoryDetail.cshtml");
        }
    }
}
