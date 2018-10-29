using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentTracker.Models;
using AppointmentTracker.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentTracker.Controllers
{
    public class ServiceProviderController : Controller
    {
        // GET: ServiceProvider
        public ActionResult Index()
        {
            return View(ServiceProviderRepository.Providers);
        }

        // GET: ServiceProvider/Details/5
        public ActionResult Details(int id)
        {
            return View(ServiceProviderRepository.Read(id));
        }

        // GET: ServiceProvider/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServiceProvider/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServiceProviderModel serviceProvider)
        {
            try
            {
                ServiceProviderRepository.Create(serviceProvider);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ServiceProviderModel serviceProvider)
        {
            try
            {
                ServiceProviderRepository.Update(id, serviceProvider);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServiceProvider/Delete/5
        public ActionResult Delete(int id)
        {
            return View(ServiceProviderRepository.Read(id));
        }

        // POST: ServiceProvider/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ServiceProviderModel serviceProvider)
        {
            try
            {
                ServiceProviderRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}