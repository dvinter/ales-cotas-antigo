using Microsoft.AspNetCore.Mvc;

namespace AlesCotas.MVC.Controllers.Balance
{
    public class BalanceController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Balance");
        }
        public IActionResult Balance()
        {
            return View();
        }
        public IActionResult BalanceRegister()
        {
            return View();
        }
        public IActionResult BalanceControl()
        {
            return View();
        }
        public IActionResult BalanceImplantation()
        {
            return View();
        }
        public IActionResult BalanceHistory()
        {
            return View();
        }
         public IActionResult BalanceAnticipation()
        {
            return View();
        }
    }
}
