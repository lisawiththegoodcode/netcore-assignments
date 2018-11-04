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
            //is this statement necessary? why?
            //var testRepo = new CustomerRepository();
            var testCustomer = new CustomerModel
            {
                Id = 5,
                Name = "Bob"
            };

            //ACT
            CustomerRepository.Create(testCustomer);
            var result = CustomerRepository.Customers.FirstOrDefault(x => x.Id == testCustomer.Id);

            //ASSERT
            Assert.Contains(result, CustomerRepository.Customers);
            Assert.Equal(testCustomer, result);
        }

        //ServiceProvider Repository Test
        [Fact]
        public void ReadMethod_ShouldReadProviderFromProviderRepository()
        {
            //ASSEMBLE
            //var testId = ServiceProviderRepository.Providers.FirstOrDefault().Id;

            var testId = 1;

            //ACT
            //ServiceProviderRepository.Read(testId);
            //var result = ServiceProviderRepository.Providers.FirstOrDefault(x => x.Id == testId);

            var result = ServiceProviderRepository.Read(testId);

            //ASSERT
            Assert.Contains(result, ServiceProviderRepository.Providers);
            Assert.True(testId == result.Id);
        }


        //Appointment Repository Test
        [Fact]
        public void UpdateMethod_ShouldEditAppointmentFromAppointmentRepository()
        {
            //ASSEMBLE
            var testAppointment = new AppointmentModel
            {
                Id = 1,
                AppointmentTime = DateTime.Today,
                Client = new CustomerModel { Id = 5, Name = "Bob1" },
                Provider = new ServiceProviderModel { Id = 5, Name = "Bob2"},
                Service = "Test Haircut"
            };

            //ACT
            AppointmentRepository.Update(1, testAppointment);
            var result = AppointmentRepository.Appointments.FirstOrDefault(x => x.Id == testAppointment.Id);

            //ASSERT
            Assert.Contains(result, AppointmentRepository.Appointments);
            Assert.Equal(testAppointment, result);

                
        }
    }
}
