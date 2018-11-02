using System;
using Xunit;
using AppointmentTracker.Services;
using AppointmentTracker.Models;
using System.Linq;

namespace AppointmentTracker.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1() //what do I want to test about my custrepo. think about methods and write at least one test per each one.
        {
            var testCustomer = new CustomerModel();
            //assemble conditions (set up test data), call the things, assert (check whether it works as expected)
            //CustomerRepository.Create();
            //Assert; ;
            //loop through appts, try to find new appt, assert it's not null, linq
            var customer = CustomerRepository.Customers.FirstOrDefault(x => x.Id == testCustomer.Id);
        }
    }
}
