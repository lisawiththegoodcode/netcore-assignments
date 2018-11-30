using System;
using Xunit;
using AppointmentTracker.Services;
using AppointmentTracker.Models;
using System.Linq;
using System.Collections.Generic; 

namespace AppointmentTracker.Tests
{
    public class RepositoryTests
    {
        //Customer Repository Test
        [Fact]
        public void CreateMethod_ShouldAddNewCustomertoCustomerRepository()
        {
            //ASSEMBLE
            //do not need to instantiate the repository because all the methods are static


            var testRepo = new Repository(null);
            var testCustomer = new CustomerModel
            {
                Id = 5,
                Name = "Bob"
            };

            //ACT
            Repository.(testCustomer);

            //ASSERT
            Assert.Contains(testCustomer, CustomerRepository.Customers);
        }
        
        //ServiceProvider Repository Test
        [Fact]
        public void ReadMethod_ShouldReadProviderFromProviderRepository()
        {
            //ASSEMBLE
            int testId = 1;

            //ACT
            var result = ServiceProviderRepository.Read(testId);

            //ASSERT
            Assert.NotNull(result);
        }

        [Fact]
        public void ReadMethod_ReturnsNullWhenItemNotFound()
        {
            //ASSEMBLE
            int testId = 100;

            //ACT
            var result = ServiceProviderRepository.Read(testId);

            //ASSERT
            Assert.Null(result);
        }


        //Appointment Repository Test
        [Fact]
        public void UpdateMethod_ShouldEditAppointmentFromAppointmentRepository()
        {
            //ASSEMBLE
            var testAppointment = new AppointmentModel
            {
                Id = 1,
                AppointmentTime = new DateTime(2018, 10, 10, 08, 00, 00),
                Client = new CustomerModel { Id = 5, Name = "Bob1" },
                Provider = new ServiceProviderModel { Id = 5, Name = "Bob2"},
                Service = "Test Haircut"
            };

            //ACT
            AppointmentRepository.Update(1, testAppointment);
            var result = AppointmentRepository.Appointments.FirstOrDefault(x => x.Id == testAppointment.Id);

            //ASSERT
            Assert.Equal(testAppointment, result);
        }
    }
}
