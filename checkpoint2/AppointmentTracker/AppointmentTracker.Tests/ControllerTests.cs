using System;
using Xunit;
using AppointmentTracker.Services;
using AppointmentTracker.Models;
using AppointmentTracker.Controllers;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AppointmentTracker.Tests
{
    public class ControllerTests
    {
        [Fact]
        public void AppointmentIndex_ReturnsAViewResult()
        {
            //ARRANGE
            var mockIRepo = new Mock<IRepository>();
            var testController = new AppointmentController(mockIRepo.Object);

            //ACT
            var result = testController.Index();

            //ASSERT
            Assert.IsType<ViewResult>(result);
        }
    }

    //test create with two tests, one that yeilds the try and one that yields the catch

    //Customer Controller Test
    //public class ControllerTests
    //{
    //    [Fact]
    //    public void CustomerIndex_ReturnsAViewResult_WithAListOfCustomers()
    //    {
    //        //assemble
    //        var testCustomerController = new CustomerController();

    //        //act
    //        var result = testCustomerController.Index();

    //        //assert
    //        var viewResult = Assert.IsType<ViewResult>(result);
    //        var model = Assert.IsAssignableFrom<IEnumerable<CustomerModel>>(
    //            viewResult.ViewData.Model);
    //        Assert.Equal(2, model.Count());
    //    }

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

    //    //AppointmentController Test
    //    [Fact]
    //    public void AppointmentCreate_TakesAnAppointmentModel_ReturnsARedirectToActionResult()
    //    {
    //        //assemble
    //        var testAppointmentController = new AppointmentController();

    //        //act
    //        var result = testAppointmentController.Create(new AppointmentModel { Id = 5, AppointmentTime = new DateTime(2018, 8, 8, 10, 0, 0), Client = new CustomerModel(), Provider = new ServiceProviderModel(), Service = "Fake" });

    //        //assert
    //        var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
    //        Assert.Equal("Index", redirectToActionResult.ActionName);

    //    }

    //    //HomeController Test
    //    [Fact]
    //    public void HomeIndex_ReturnsAViewResult()
    //    {
    //        //assemble
    //        var testHomeController = new HomeController();

    //        //act
    //        var result = testHomeController.Index();

    //        //assert
    //        var viewResult = Assert.IsType<ViewResult>(result);
    //    }

    //}
}
