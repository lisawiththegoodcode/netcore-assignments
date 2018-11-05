using System;
using Xunit;
using AppointmentTracker.Services;
using AppointmentTracker.Models;
using AppointmentTracker.Controllers;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentTracker.Tests
{
    //Customer Controller Test
    public class ControllerTests
    {
        [Fact]
        public void CustomerIndex_ReturnsAViewResult()
        {
            //assert
            var testCustomerController = new CustomerController();

            //act
            var result = testCustomerController.Index();

            //assert
            Assert.IsType<ViewResult>(result);

        }

        [Fact]
        public void ProviderCreate
        {

        }

    }
}
