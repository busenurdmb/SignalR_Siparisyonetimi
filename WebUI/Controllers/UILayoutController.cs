﻿using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
