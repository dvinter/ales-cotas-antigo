using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlesCotas.MVC.Controllers.Requests.Post.Simple
{
    [Authorize]
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Requests", null);
        }
        public IActionResult ListRequestPost()
        {
            return View("Views/Requests/Post/Simple/ListRequestPost.cshtml");
        }
        public IActionResult PostApproved()
        {
            return View("Views/Requests/Post/Simple/PostApproved.cshtml");
        }
        public IActionResult PostApprovedEdit()
        {
            return View("Views/Requests/Post/Simple/PostApprovedEdit.cshtml");
        }
        public IActionResult Post()
        {
            return View("Views/Requests/Post/Simple/Post.cshtml");
        }
        public IActionResult PostCreate()
        {
            return View("Views/Requests/Post/Simple/PostCreate.cshtml");
        }
        public IActionResult PostEdit(int id)
        {
            return View("Views/Requests/Post/Simple/PostEdit.cshtml");
        }
        public ActionResult FormPost(int id)
        {
            return View("Views/Requests/Post/Simple/FormPost.cshtml");
        }
        public ActionResult FormPostEdit(int id)
        {
            return View("Views/Requests/Post/Simple/FormPostEdit.cshtml");
        }
           public ActionResult PostHistory()
        {
            return View("Views/History/Post/Simple/PostHistory.cshtml");
        }
        public ActionResult PostHistoryDetail(int id)
        {
            return View("Views/History/Post/Simple/PostHistoryDetail.cshtml");
        }
    }
}
