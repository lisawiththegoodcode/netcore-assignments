using AppointmentTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentTracker.Services
{
    public class AppointmentRepository
    {
        private static List<AppointmentModel> _appointments = new List<AppointmentModel>
        {
            new AppointmentModel
            {
                Id = 1,
                AppointmentTime = DateTime.Today,
                CustomerId = 1,
                ServiceProviderId = 2,
                Service = "Haircut"
            },
            new AppointmentModel
            {
                Id = 2,
                AppointmentTime = DateTime.Today.AddDays(4),
                CustomerId = 1,
                ServiceProviderId = 1,
                Service = "Nails"
            },
            new AppointmentModel
            {
                Id = 3,
                AppointmentTime = DateTime.Today.AddDays(-4),
                CustomerId = 2,
                ServiceProviderId = 1,
                Service = "Acupuncture"
            },
        };

        public static IReadOnlyList<AppointmentModel> Appointments => _appointments;
    }
}
