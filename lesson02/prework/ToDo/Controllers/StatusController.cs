using System;
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
        // GET: Status
        public ActionResult Index()
        {
            return View(Repository.Statuses.Values);
        }

        // GET: Status/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Status/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Status collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: Status/Edit
        public ActionResult Edit(int id)
        {
            return View((Repository.Statuses.FirstOrDefault(x => x.Key == id)).Value);
        }

        // POST: Status/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Status collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
