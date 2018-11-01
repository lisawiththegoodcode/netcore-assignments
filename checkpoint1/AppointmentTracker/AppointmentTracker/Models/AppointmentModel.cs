using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentTracker.Models
{
    public class AppointmentModel
    {
        public int Id { get; set; }

        public DateTime AppointmentTime { get; set; }

        public int CustomerId { get; set; }
        [UIHint("Client)")]
        public CustomerModel Client { get; set; }

        public int ServiceProviderId { get; set; }
        [UIHint("Provider")]
        public ServiceProviderModel Provider { get; set; }

        public string Service { get; set; }

    }
}
