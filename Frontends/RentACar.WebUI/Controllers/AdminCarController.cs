using Microsoft.AspNetCore.Mvc;

namespace RentACar.WebUI.Controllers
{
    public class AdminCarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
