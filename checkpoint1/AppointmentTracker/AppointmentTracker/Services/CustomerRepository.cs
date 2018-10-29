using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentTracker.Models;

namespace AppointmentTracker.Services
{
    public class CustomerRepository
    {
        private static List<CustomerModel> _customers = new List<CustomerModel>
        {
            new CustomerModel { Id = 1, Name = "John Doe"}, 
            new CustomerModel {Id = 2, Name = "Jane Doe"}
        };

        public static IReadOnlyList<CustomerModel> Customers => _customers;

    }
}
