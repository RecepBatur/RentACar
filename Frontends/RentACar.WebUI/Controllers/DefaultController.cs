﻿using Microsoft.AspNetCore.Mvc;

namespace RentACar.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
