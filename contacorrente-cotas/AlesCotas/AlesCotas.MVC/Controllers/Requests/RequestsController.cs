using AlesCotas.Application.Interfaces.Servicos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlesCotas.MVC.Controllers.Requests
{
    [Authorize]
    public class RequestsController : Controller
    {
        private readonly IProdutoAppServico _produtoServ;
        public RequestsController(IProdutoAppServico produtoServ)
        {
            _produtoServ = produtoServ;
        }
        // GET: RequestsController
        public ActionResult Index()
        {
            return RedirectToAction("Requests");
        }
        public ActionResult Requests()
        {
            return View();
        }
        public IActionResult ListRequestFuel()
        {
            return View("Views/Requests/Fuel/ListRequestFuel.cshtml");
        }
        public IActionResult Fuel()
        {
            return View("Views/Requests/Fuel/Fuel.cshtml", _produtoServ.Listar("Combustível"));
        }
        public IActionResult FuelEditCreate()
        {
            return View("Views/Requests/Fuel/FuelEditCreate.cshtml");
        }
        public ActionResult FormFuel(int id)
        {
            return View("Views/Requests/Fuel/FormFuel.cshtml");
        }
        public IActionResult Copy()
        {
            return View("Views/Requests/Copy/Copy.cshtml");
        }
        public IActionResult CopyEditCreate()
        {
            return View("Views/Requests/Copy/CopyEditCreate.cshtml");
        }
        public ActionResult FormCopy(int id)
        {
            return View("Views/Requests/Copy/FormCopy.cshtml");
        }
        public IActionResult ListRequestCopy()
        {
            return View("Views/Requests/Copy/ListRequestCopy.cshtml");
        }
        public IActionResult ListRequestTicket()
        {
            return View("Views/Requests/Ticket/ListRequestTicket.cshtml");
        }
        public ActionResult FormTicket(int? id)
        {
            return View("Views/Requests/Ticket/FormTicket.cshtml");
        }
        public IActionResult ListRequestDaily()
        {
            return View("Views/Requests/Daily/ListRequestDaily.cshtml");
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
        public ActionResult FormPeriodicos(int? id)
        {
            return View("Views/Requests/Periodicos/FormPeriodicos.cshtml");
        }
        public ActionResult FormPeriodicosGestor(int? id)
        {
            return View("Views/Requests/Periodicos/FormPeriodicosGestor.cshtml");
        }
        public IActionResult ListRequestPeriodicos()
        {
            return View("Views/Requests/Periodicos/ListRequestPeriodicos.cshtml");
        }
        public IActionResult PostRedir()
        {
            return View("Views/Requests/Post/PostRedir.cshtml");
        }


        // GET: RequestsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RequestsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RequestsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RequestsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RequestsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RequestsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RequestsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
