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

        [Required]
        public DateTime AppointmentTime { get; set; }

        [UIHint("Client")]
        public CustomerModel Client { get; set; }

        [UIHint("Provider")]
        public ServiceProviderModel Provider { get; set; }

        [Required]
        public string Service { get; set; }
    }
}
