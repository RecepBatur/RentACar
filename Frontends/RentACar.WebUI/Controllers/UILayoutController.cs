using Microsoft.AspNetCore.Mvc;

namespace RentACar.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
