using Microsoft.AspNetCore.Mvc;

namespace RentACar.WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult AdminHeaderPartial()
        {
            return PartialView();
        }
        public PartialViewResult AdminNavbarPartial()
        {
            return PartialView();
        }
        public PartialViewResult AdminSidebarPartial()
        {
            return PartialView();
        }
        public PartialViewResult AdminFooterbarPartial()
        {
            return PartialView();
        }
        public PartialViewResult AdminScriptbarPartial()
        {
            return PartialView();
        }
    }
}
