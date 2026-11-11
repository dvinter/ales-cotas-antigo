using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlesCotas.MVC.Controllers.Requests.Periodicos
{
    [Authorize]
    public class PeriodicosController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Requests", null);
        }
        public ActionResult FormPeriodicos(int? id)
        {
            return View("Views/Requests/Periodicos/FormPeriodicos.cshtml");
        }
        //Entrada no History (remover)
        public ActionResult FormPeriodicosEdit(int? id)
        {
            return View("Views/Requests/Periodicos/FormPeriodicosEdit.cshtml");
        }
        public ActionResult PeriodicosApproved(int? id)
        {
            return View("Views/Requests/Periodicos/PeriodicosApproved.cshtml");
        }
        public ActionResult FormPeriodicosGestor(int? id)
        {
            return View("Views/Requests/Periodicos/FormPeriodicosGestor.cshtml");
        }
        public IActionResult ListRequestPeriodicos()
        {
            return View("Views/Requests/Periodicos/ListRequestPeriodicos.cshtml");
        }
          public ActionResult PeriodicosHistory()
        {
            return View("Views/History/Periodicos/PeriodicosHistory.cshtml");
        }
        public ActionResult PeriodicosHistoryDetail(int id)
        {
            return View("Views/History/Periodicos/PeriodicosHistoryDetail.cshtml");
        }
    }
}
