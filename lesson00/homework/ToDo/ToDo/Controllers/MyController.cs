using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ToDo.Controllers
{
    public class MyController : Controller
    {
        public IActionResult Index()
        {
            int hour = DateTime.Now.Hour;
            var message = hour < 12 ? "Good Morning" : "Good Afternoon";
            ViewData["SpanishGreeting"] = "Buenos Dias";
            ViewBag.SpanishGreeting = "Buenos Dias again";
            return View("Greeting", message);
        }
    }
}