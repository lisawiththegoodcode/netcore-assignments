using Forum.Controllers;
using Forum.Data;
using Forum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject1
{
    public class MessagesControllerTests
    {
        [Fact]
        public async Task MessageCreate_RedirectsToParentThreadDetailsPage()
        {
            //assemble
            //messages controller must have a context
            var contextMock = new Mock<ForumContext>(new DbContextOptionsBuilder<ForumContext>().Options);
            contextMock.Setup(c => c.Add(It.IsAny<Message>())).Returns<EntityEntry<Message>>(null);
            contextMock.Setup(c => c.SaveChangesAsync(CancellationToken.None)).Returns(Task.FromResult(0));
            var controller = new MessagesController(contextMock.Object);
            var message = new Message() { ThreadId = 1 }; //must be an integer, non-zero bc zero is the default

            //act
            var actionResult = await controller.Create(message);

            //assert
            Assert.IsType<RedirectToActionResult>(actionResult);
            var redirectResult = actionResult as RedirectToActionResult;
            Assert.Equal("Threads", redirectResult.ControllerName);
            Assert.Equal("Details", redirectResult.ActionName);
            Assert.Equal(message.ThreadId, redirectResult.RouteValues["Id"]);

        }
    }
}
