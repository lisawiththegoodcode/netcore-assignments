using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AppointmentTracker.Models;


namespace AppointmentTracker.Services
{
    public class ServiceProviderRepository
    {
        private static int serviceProviderCounter = 2;

        private static List<ServiceProviderModel> _providers = new List<ServiceProviderModel>
        {
            new ServiceProviderModel { Id = 1, Name = "Oliver Magoo"},
            new ServiceProviderModel {Id = 2, Name = "Oala Bear"}
        };

        public static IReadOnlyList<ServiceProviderModel> Providers => _providers;

        //Create Method
        public static void Create(ServiceProviderModel serviceProvider)
        {
            serviceProvider.Id = Interlocked.Increment(ref serviceProviderCounter);
            _providers.Add(serviceProvider);
        }

        //Read Method
        public static ServiceProviderModel Read(int id)
        {
            return _providers.Find(x => x.Id == id);
        }

        //Update Method
        public static void Update(int id, ServiceProviderModel serviceProvider)
        {
            var index = _providers.FindIndex(x => x.Id == id);
            _providers.RemoveAt(index);
            serviceProvider.Id = id;
            _providers.Insert(index, serviceProvider);
        }

        //Delete Method
        public static void Delete(int id)
        {
            var index = _providers.FindIndex(x => x.Id == id);
            _providers.RemoveAt(index);
        }
    }
}
