using AppointmentTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AppointmentTracker.Services
{
    public class AppointmentRepository
    {

        private static int appointmentCounter = 3;

        private static List<AppointmentModel> _appointments = new List<AppointmentModel>
        {
            new AppointmentModel
            {
                Id = 1,
                AppointmentTime = DateTime.Today,
                CustomerId = 1,
                Client = CustomerRepository.Read(1),
                ServiceProviderId = 2,
                Provider = ServiceProviderRepository.Read(2),
                Service = "Haircut"
            },
            new AppointmentModel
            {
                Id = 2,
                AppointmentTime = DateTime.Today.AddDays(4),
                CustomerId = 1,
                Client = CustomerRepository.Read(1),
                ServiceProviderId = 1,
                Provider = ServiceProviderRepository.Read(1),
                Service = "Nails"
            },
            new AppointmentModel
            {
                Id = 3,
                AppointmentTime = DateTime.Now,
                CustomerId = 2,
                Client = CustomerRepository.Read(2),
                ServiceProviderId = 1,
                Provider = ServiceProviderRepository.Read(1),
                Service = "Acupuncture"
            },
        };

        public static IReadOnlyList<AppointmentModel> Appointments => _appointments;

        //Create Method
        public static void Create(AppointmentModel appointment)
        {
            if (!IsAppointmentAvailable(appointment))
            {
                throw new Exception("The selected service provider is not available for an appointment at this time.");
            }

            appointment.Id = Interlocked.Increment(ref appointmentCounter);
            _appointments.Add(appointment);
        }

        //Read Method
        public static AppointmentModel Read(int id)
        {
            return _appointments.Find(x => x.Id == id);
        }

        //Update Method
        public static void Update(int id, AppointmentModel appointment)
        {
            var index = _appointments.FindIndex(x => x.Id == id);
            _appointments.RemoveAt(index);
            appointment.Id = id;
            _appointments.Insert(index, appointment);
        }

        //Delete Method
        public static void Delete(int id)
        {
            var index = _appointments.FindIndex(x => x.Id == id);
            _appointments.RemoveAt(index);
        }

        //Appointment Checker Method
        public static bool IsAppointmentAvailable(AppointmentModel proposedAppt)
        {
            // loop thru all appointments to check if the proposed service provider is already booked for proposed start time

            //NOTE: I chose to assume a provider would be free so long that two appts did not start at the same time. 
            //If I were to develop this further, services could have a defined time allotments that I would take into consideration in the provider's availability.

            foreach (var appt in _appointments)
            {
                if (appt.AppointmentTime == proposedAppt.AppointmentTime && appt.ServiceProviderId == proposedAppt.ServiceProviderId)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
