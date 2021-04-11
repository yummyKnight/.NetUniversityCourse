using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using WebApp.BLL.Implementations;
using WebApp.DAL;
using WebApp.Domain;
using WebApp.Domain.Contracts;
using FluentAssertions;
using AutoFixture;
using Ploeh.AutoFixture;
using WebApp.Domain.Models;

namespace WebApp.BLL.TestsUnit {
    [TestFixture]
    public class ServicesTest {
        
        [Test]
        public async Task ValidateAsync_ClientExists_DoesNothing() {
            // Arrange
            var clientContainer = new Mock<IClientContainer>();

            var client = new Client(1);
            var clientRepository = new Mock<IClientRepository>();
            clientRepository.Setup(x => x.GetByAsync(clientContainer.Object)).ReturnsAsync(client);

            var clientGetService = new ClientGetService(clientRepository.Object);

            // Act
            var action = new Func<Task>(() => clientGetService.ValidateAsync(clientContainer.Object));

            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }
        [Test]
        public async Task ValidateAsync_DepartmentNotExists_ThrowsError() {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();

            var clientContainer = new Mock<IClientContainer>();
            clientContainer.Setup(x => x.ClientId).Returns(id);

            var clientRep = new Mock<IClientRepository>();
            clientRep.Setup(x => x.GetByAsync(clientContainer.Object)).ReturnsAsync((Client) null);

            var clientGetService = new ClientGetService(clientRep.Object);

            // Act
            var action = new Func<Task>(() => clientGetService.ValidateAsync(clientContainer.Object));

            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Department not found by id {id}");
        }
    }
}