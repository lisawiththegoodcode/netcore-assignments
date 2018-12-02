using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppointmentTracker.Data;
using AppointmentTracker.Models;

namespace AppointmentTracker.Services
{
    public class Repository : IRepository
    {
        private readonly SpaAppContext _spaAppContext;
        private readonly IReadOnlySpaAppContext _readOnlySpaAppContext;

        public Repository(SpaAppContext SpaAppContext, IReadOnlySpaAppContext readOnlySpaAppContext)
        {
            _spaAppContext = SpaAppContext;
            _readOnlySpaAppContext = readOnlySpaAppContext;
        }

        public IQueryable<AppointmentModel> Appointments => _readOnlySpaAppContext.Appointments;

        public IQueryable<CustomerModel> Customers => _readOnlySpaAppContext.Customers;

        public IQueryable<ServiceProviderModel> Providers => _readOnlySpaAppContext.Providers;

        #region Appointment Methods
        public void AddAppointment(AppointmentModel appointment)
        {
            if (!IsProviderAvailable(appointment))
            {
                throw new Exception("The selected service provider is not available for an appointment at this time.");
            }

            if (!IsClientAvailable(appointment))
            {
                throw new Exception("The selected customer already has an appointment booked at this time.");
            }
            //appointment.Provider = GetProvider(appointment.ProviderId);
            //appointment.Client = GetCustomer(appointment.ClientId);
            _spaAppContext.Appointments.Add(appointment);
            _spaAppContext.SaveChanges();
        }

        public void UpdateAppointment(int id, AppointmentModel appointment)
        {
            if (!IsProviderAvailable(appointment))
            {
                throw new Exception("The selected service provider is not available for an appointment at this time.");
            }

            if (!IsClientAvailable(appointment))
            {
                throw new Exception("The selected customer already has an appointment booked at this time.");
            }

            //appointment.Provider = GetProvider(appointment.Provider.Id);
            //appointment.Client = GetCustomer(appointment.Client.Id);
            appointment.Id = id;
            _spaAppContext.Appointments.Update(appointment);
            _spaAppContext.SaveChanges();
        }

        public void DeleteAppointment(int id)
        {
            var toBeDeleted = _spaAppContext.Appointments.First(SelectAppointmentById(id));
            _spaAppContext.Appointments.Remove(toBeDeleted);
            _spaAppContext.SaveChanges();
        }

        public AppointmentModel GetAppointment(int id)
        {
            return _readOnlySpaAppContext.Appointments
                .Include(x => x.Provider)
                .Include(x => x.Client)
                .First(SelectAppointmentById(id));
        }
        #endregion

        #region Appointment Checker Methods
        private bool IsProviderAvailable(AppointmentModel proposedAppt)
        {
            // loop thru all appointments to check if the proposed service provider is already booked for proposed start time

            //NOTE: I chose to assume a provider would be free so long that two appts did not start at the same time. 
            //If I were to develop this further, services could have a defined time allotments that I would take into consideration in the provider's availability.

            return !_readOnlySpaAppContext.Appointments
                .Any(appt => appt.AppointmentTime == proposedAppt.AppointmentTime 
                    && appt.ProviderId == proposedAppt.ProviderId 
                    && appt.Id != proposedAppt.Id);

            //foreach (var appt in _readOnlySpaAppContext.Appointments)
            //{
            //    if (appt.AppointmentTime == proposedAppt.AppointmentTime && appt.ProviderId == proposedAppt.ProviderId && appt.Id != proposedAppt.Id)
            //    {
            //        return false;
            //    }
            //}
            //return true;
        }

        private bool IsClientAvailable(AppointmentModel proposedAppt)
        {
            // loop thru all appointments to check if the client already has an appt booked for proposed start time

            return !_readOnlySpaAppContext.Appointments.Any(appt => appt.AppointmentTime == proposedAppt.AppointmentTime && appt.ClientId == proposedAppt.ClientId && appt.Id != proposedAppt.Id);

            //foreach (var appt in _readOnlySpaAppContext.Appointments)
            //{
            //    if (appt.AppointmentTime == proposedAppt.AppointmentTime && appt.ClientId == proposedAppt.ClientId && appt.Id != proposedAppt.Id)
            //    {
            //        return false;
            //    }
            //}
            //return true;
        }
        #endregion

        #region Provider Methods
        public void AddProvider(ServiceProviderModel provider)
        {
            _spaAppContext.Providers.Add(provider);
            _spaAppContext.SaveChanges();
        }

        public void UpdateProvider(int id, ServiceProviderModel provider)
        {
            provider.Id = id;
            _spaAppContext.Providers.Update(provider);
            _spaAppContext.SaveChanges();
        }

        public void DeleteProvider(int id)
        {
            var toBeDeleted = _spaAppContext.Providers.First(SelectProvidersById(id));
            _spaAppContext.Providers.Remove(toBeDeleted);
            _spaAppContext.SaveChanges();
        }

        public ServiceProviderModel GetProvider(int id)
        {
            return _readOnlySpaAppContext.Providers.First(SelectProvidersById(id));
        }

        public List<AppointmentModel> GetAppointmentsForProvider(int providerID)
        {
            return _spaAppContext.Appointments
                .Where(appt => appt.Provider.Id == providerID)
                .OrderBy(appt => appt.AppointmentTime)
                .ToList();
        }
        #endregion

        #region Customer Methods
        public void AddCustomer(CustomerModel customer)
        {
            _spaAppContext.Customers.Add(customer);
            _spaAppContext.SaveChanges();
        }

        public void UpdateCustomer(int id, CustomerModel customer)
        {
            customer.Id = id;
            _spaAppContext.Customers.Update(customer);
            _spaAppContext.SaveChanges();
        }

        public void DeleteCustomer(int id)
        {
            var toBeDeleted = _spaAppContext.Customers.First(SelectCustomersById(id));
            _spaAppContext.Customers.Remove(toBeDeleted);
            _spaAppContext.SaveChanges();
        }

        public CustomerModel GetCustomer(int id)
        {
            return _readOnlySpaAppContext.Customers.First(SelectCustomersById(id));
        }
        #endregion

        #region Selector Functions
        private static Func<AppointmentModel, bool> SelectAppointmentById(int id)
        {
            return appointment => appointment.Id == id;
        }

        private static Func<ServiceProviderModel, bool> SelectProvidersById(int id)
        {
            return provider => provider.Id == id;
        }

        private static Func<CustomerModel, bool> SelectCustomersById(int id)
        {
            return customer => customer.Id == id;
        }

        public void Dispose()
        {
            _spaAppContext?.Dispose();
            (_readOnlySpaAppContext as IDisposable)?.Dispose();
        }
        #endregion
    }
}
