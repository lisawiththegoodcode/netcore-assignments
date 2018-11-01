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
    public class CustomerController : Controller
    {
        // GET: ServiceProvider
        public ActionResult Index()
        {
            return View(CustomerRepository.Customers);
        }

        // GET: ServiceProvider/Details/5
        public ActionResult Details(int id)
        {
            return View(CustomerRepository.Read(id));
        }

        // GET: ServiceProvider/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServiceProvider/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerModel customer)
        {
            try
            {
                CustomerRepository.Create(customer);
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
            return View(CustomerRepository.Read(id));
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomerModel customer)
        {
            try
            {
                CustomerRepository.Update(id, customer);
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
            return View(CustomerRepository.Read(id));
        }

        // POST: ServiceProvider/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, CustomerModel customerProvider)
        {
            try
            {
                CustomerRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}