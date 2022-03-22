using System;
using AireLogic.Api.Controllers;
using AireLogic.Api.Entities;
using AireLogic.Api.Services;
using Moq;
using Xunit;

namespace AireLogic.Technical.Tests
{
    public class PersonContollerShould
    {
        private readonly Mock<IBugtrackerRepository> repository;

        public PersonContollerShould()
        {
            repository = new Mock<IBugtrackerRepository>();
        }

        [Fact]
        public void ControllerReturnsAllPeople()
        {
            var controller = new PeopleController(repository.Object);

            var result = controller.Get();
            Assert.NotNull(result);
        }

        [Fact]
        public void ControllerReturnsPersonForId()
        {
            var id = Guid.NewGuid();
            repository.Setup(x => x.GetPersonById(id)).Returns(new Person
            {
                Id = id
            });

            var controller = new PeopleController(repository.Object);

            var result = controller.Get();
            Assert.NotNull(result);
        }
    }
}
