using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoApp.Controllers
{
    public class StatusController : Controller
    {
        private static List<Status> statusList = new List<Status>
        {
            { new Status { Id = 1, Value = "Not Started" } },
            { new Status { Id = 2, Value = "In Progress" } },
            { new Status { Id = 3, Value = "Done" } }
        };

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(statusList);
        }
    }
}
