using Microsoft.AspNetCore.Mvc;


namespace LibrarySystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
