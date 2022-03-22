using System;
using AireLogic.Api.Controllers;
using AireLogic.Api.Entities;
using AireLogic.Api.Services;
using Moq;
using Xunit;

namespace AireLogic.Technical.Tests
{
    public class BugContollerShould
    {
        private readonly Mock<IBugtrackerRepository> repository;

        public BugContollerShould()
        {
            repository = new Mock<IBugtrackerRepository>();
        }

        [Fact]
        public void ControllerReturnsAllBugs()
        {
            var controller = new BugsController(repository.Object);

            var result = controller.Get();
            Assert.NotNull(result);
        }

        [Fact]
        public void ControllerReturnsAllBugForId()
        {
            var id = Guid.NewGuid();
            repository.Setup(x => x.GetBugById(id)).Returns(new Bug
            {
                Id = id
            });

            var controller = new BugsController(repository.Object);

            var result = controller.Get();
            Assert.NotNull(result);            
        }
    }
}
