using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AppointmentTracker.Models;

namespace AppointmentTracker.Services
{
    public class CustomerRepository
    {
        private static int customerCounter = 2;

        private static List<CustomerModel> _customers = new List<CustomerModel>
        {
            new CustomerModel { Id = 1, Name = "John Doe"}, 
            new CustomerModel {Id = 2, Name = "Jane Doe"}
        };

        public static IReadOnlyList<CustomerModel> Customers => _customers;


        //Create Method
        public static void Create(CustomerModel customer)
        {
            customer.Id = Interlocked.Increment(ref customerCounter);
            _customers.Add(customer);
        }

        //Read Method
        public static CustomerModel Read(int id)
        {
            return _customers.Find(x => x.Id == id);
        }

        //Update Method
        public static void Update(int id, CustomerModel customer)
        {
            var index = _customers.FindIndex(x => x.Id == id);
            _customers.RemoveAt(index);
            customer.Id = id;
            _customers.Insert(index, customer);
        }

        //Delete Method
        public static void Delete(int id)
        {
            var index = _customers.FindIndex(x => x.Id == id);
            _customers.RemoveAt(index);
        }
    }
}
