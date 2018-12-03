using System;
using Xunit;
using AppointmentTracker.Services;
using AppointmentTracker.Models;
using AppointmentTracker.Controllers;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using AppointmentTracker.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace AppointmentTracker.Tests
{
    public class ControllerTests
    {
        //HELPER METHOD THAT INSTANTIATES THE IREPOSITORY
        private IRepository CreateIRepository()
        {
            var mockIRepo = new Mock<IRepository>();
            return mockIRepo.Object;
        }

        //APPOINTMENT CONTROLLER TEST
        [Fact]
        public void AppointmentIndex_ReturnsAViewResult()
        {
            //ARRANGE
            var testController = new AppointmentController(CreateIRepository());

            //ACT
            var result = testController.Index();

            //ASSERT
            Assert.IsType<ViewResult>(result);
        }

        //CUST CONTROLLER TEST
        [Fact]
        public void CustomerCreatePost_RedirectsToIndexPage()
        {
            //ARRANGE
            var testController = new CustomerController(CreateIRepository());
            var testCustomer = new CustomerModel();

            //ACT
            var result = testController.Create(testCustomer);

            //ASSERT
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        //CUST CONTROLLER TEST
        [Fact]
        public void CustomerCreateGet_ReturnsAViewResult()
        {
            //ARRANGE
            var testController = new CustomerController(CreateIRepository());

            //ACT
            var result = testController.Create();

            //ASSERT
            Assert.IsType<ViewResult>(result);
        }

        //SERVICE PROVIDER CONTROLLER TEST
        [Fact]
        public void ServiceProviderDetails_ReturnsAViewResult()
        {
            //ARRANGE
            var testController = new ServiceProviderController(CreateIRepository());
            var testServiceProvider = new ServiceProviderModel { Id = 1 };

            //ACT
            var result = testController.Details(testServiceProvider.Id, testServiceProvider);

            //ASSERT
            Assert.IsType<ViewResult>(result);
            Assert.Equal(1, testServiceProvider.Id);
        }

        //HomeController Test
        [Fact]
        public void HomeIndex_ReturnsAViewResult()
        {
            //assemble
            var testHomeController = new HomeController();

            //act
            var result = testHomeController.Index();

            //assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }
    }


    //    //ServiceProviderController Test
    //    [Fact]
    //    public void ProviderDetails_TakesAnInt_ReturnsAViewResult_WithServiceProviderModelData()
    //    {
    //        //FETCHES A SERVICE PROVIDER WHEN GIVEN AN EXISTING ID
    //        //assemble
    //        var testServiceProviderController = new ServiceProviderController();

    //        //act
    //        var result = testServiceProviderController.Details(1);

    //        //asert
    //        var viewResult = Assert.IsType<ViewResult>(result);
    //        var model = Assert.IsAssignableFrom<ServiceProviderModel>(viewResult.ViewData.Model);
    //        Assert.NotNull(model.Name);
    //    }

    //}
}
