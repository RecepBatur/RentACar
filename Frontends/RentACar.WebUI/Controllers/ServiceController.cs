using Microsoft.AspNetCore.Mvc;


namespace RentACar.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
