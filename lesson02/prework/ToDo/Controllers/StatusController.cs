﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;
using ToDoApp.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoApp.Controllers
{
    public class StatusController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(Repository.ToDos);
        }
    }
}
