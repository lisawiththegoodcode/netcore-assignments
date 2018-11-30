using System;
using Xunit;
using AppointmentTracker.Services;
using AppointmentTracker.Models;
using System.Linq;
using System.Collections.Generic;
using Moq;
using AppointmentTracker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading;
using System.Threading.Tasks;

namespace AppointmentTracker.Tests
{
    public class RepositoryTests
    {
        //Customer Repository Test
        [Fact]
        public void CreateMethod_ShouldAddNewCustomertoRepository()
        {
            //ASSEMBLE
            //previously did not need to instantiate the repository because all the methods are static, now it has a ctor that takes a context and icontext
            var contextMock = new Mock<SpaAppContext>(new DbContextOptionsBuilder<SpaAppContext>().Options);
            contextMock.Setup(c => c.Add(It.IsAny<AppointmentModel>())).Returns<EntityEntry<AppointmentModel>>(null);
            contextMock.Setup(c => c.SaveChangesAsync(CancellationToken.None)).Returns(Task.FromResult(0));
            //var controller = new MessagesController(contextMock.Object);
            //var message = new Message() { ThreadId = 1 }; //must be an integer, non-zero bc zero is the default


            var testRepo = new Repository(contextMock.Object); //, need to add icontext);
            var testCustomer = new CustomerModel
            {
                Id = 5,
                Name = "Bob"
            };

            //ACT
            testRepo.AddCustomer(testCustomer);

            //ASSERT
            Assert.Contains(testCustomer, testRepo.Customers);
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
