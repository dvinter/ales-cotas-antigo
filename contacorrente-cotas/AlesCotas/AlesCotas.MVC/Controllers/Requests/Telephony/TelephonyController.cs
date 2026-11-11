using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlesCotas.MVC.Controllers.Requests.Telephony
{
    [Authorize]
    public class TelephonyController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Requests", null);
        }
        public IActionResult Telephony()
        {
            return View("Views/Requests/Telephony/Telephony.cshtml");
        }
        public IActionResult TelephonyCreate()
        {
            return View("Views/Requests/Telephony/TelephonyCreate.cshtml");
        }
        public IActionResult TelephonyEdit()
        {
            return View("Views/Requests/Telephony/TelephonyEdit.cshtml");
        }
        public ActionResult FormTelephony(int id)
        {
            return View("Views/Requests/Telephony/FormTelephony.cshtml");
        }
        public ActionResult TelephonyHistory()
        {
            return View("Views/History/Telephony/TelephonyHistory.cshtml");
        }
        public ActionResult TelephonyHistoryDetail(int id)
        {
            return View("Views/History/Telephony/TelephonyHistoryDetail.cshtml");
        }
    }
}
