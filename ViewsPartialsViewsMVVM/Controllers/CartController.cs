using Microsoft.AspNetCore.Mvc;

namespace ViewsPartialsViewsMVVM.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Cart";
            return View();
        }
    }
}
