using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentTracker.Models
{
    public class AppointmentModel
    {
        public int Id { get; set; }
        public DateTime AppointmentTime { get; set; }
        public int CustomerId { get; set; }
        public CustomerModel Client { get; set; }
        public int ServiceProviderId { get; set; }
        public ServiceProviderModel Provider { get; set; }
        public string Service { get; set; }

    }
}
