using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlesCotas.MVC.Controllers.Requests.Ticket
{
    [Authorize]
    public class TicketController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Requests", null);
        }
        public IActionResult ListRequestTicket()
        {
            return View("Views/Requests/Ticket/ListRequestTicket.cshtml");
        }
        public ActionResult FormTicket(int? id)
        {
            return View("Views/Requests/Ticket/FormTicket.cshtml");
        }
        public ActionResult TicketApproved(int? id)
        {
            return View("Views/Requests/Ticket/TicketApproved.cshtml");
        }
         public ActionResult TicketHistory()
        {
            return View("Views/History/Ticket/TicketHistory.cshtml");
        }
        public ActionResult TicketHistoryDetail(int id)
        {
            return View("Views/History/Ticket/TicketHistoryDetail.cshtml");
        }
    }
}
