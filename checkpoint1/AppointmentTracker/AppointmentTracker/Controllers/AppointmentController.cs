﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentTracker.Models;
using AppointmentTracker.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentTracker.Controllers
{
    public class AppointmentController : Controller
    {
        // GET: Appointment
        public ActionResult Index()
        {
            return View(AppointmentRepository.Appointments);
        }

        // GET: Appointment/Details/5
        public ActionResult Details(int id)
        {
            return View(AppointmentRepository.Read(id));
        }

        // GET: Appointment/Create
        public ActionResult Create()
        {                
                return View();
        }

        // POST: Appointment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AppointmentModel Appt)
        {
            try
            {
                AppointmentRepository.Create(Appt);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                //TODO: figure out bet way to display error message
                Console.WriteLine(e);
                return View();
            }
        }

        // GET: Appointment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Appointment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AppointmentModel Appt)
        {
            try
            {
                AppointmentRepository.Update(id, Appt);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Appointment/Delete/5
        public ActionResult Delete(int id)
        {
            return View(AppointmentRepository.Read(id));
        }

        // POST: Appointment/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AppointmentModel Appt)
        {
            try
            {
                AppointmentRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}