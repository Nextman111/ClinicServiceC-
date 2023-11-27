using ClinicService.Controllers;
using ClinicService.Models;
using ClinicService.Models.Requests;
using ClinicService.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServiceTests
{
    public class ClientControllerTests
    {
        private ClientController _clientController;
        public Mock<IClientRepository> _mockClientRepository;

        public ClientControllerTests()
        {
            _mockClientRepository = new Mock<IClientRepository>();
            _clientController = new ClientController(_mockClientRepository.Object);
        }

        [Fact]
        public void GetAllClientsTest()
        {
            // Подготовка данных для тестирования
            List<Client> clientsList = new List<Client>();
            clientsList.Add(new Client());
            clientsList.Add(new Client());
            clientsList.Add(new Client());

            _mockClientRepository.Setup(repository =>
                repository.GetAll()).Returns(clientsList);

            // Исполнение тестируемого метода
            var operationResult = _clientController.GetAll();

            //Подготовка эталонного результата и проверка результата
            Assert.IsType<OkObjectResult>(operationResult.Result);
            var okObjectResult = (OkObjectResult)operationResult.Result;

            Assert.IsAssignableFrom<List<Client>>(okObjectResult.Value);
            _mockClientRepository.Verify(repository
                => repository.GetAll(), Times.AtLeastOnce);

        }

        [Fact]
        public void CreateClientTest()
        {
            // Подготовка данных для тестирования
            var createClientRequest = new CreateClientRequest();
            createClientRequest.FirstName = "Test";
            createClientRequest.SurName = "Test";
            createClientRequest.Patronymic = "Test";
            createClientRequest.Birthday = DateTime.Now.AddYears(-33);
            createClientRequest.Document = "AAAD34fdsfv";

            _mockClientRepository.Setup(repository =>
                repository.Create(It.IsNotNull<Client>())).Returns(1).Verifiable();

            // Исполнение тестируемого метода
            var operationResult = _clientController.Create(createClientRequest);

            //Подготовка эталонного результата и проверка результата
            Assert.IsType<OkObjectResult>(operationResult.Result);
            var okObjectResult = (OkObjectResult)operationResult.Result;

            Assert.IsAssignableFrom<int>(okObjectResult.Value);
            _mockClientRepository.Verify(repository
                => repository.Create(It.IsNotNull<Client>()), Times.AtMostOnce());
        }

        public static object[][] CorrectCreateClient =
        {
            new object[] { new DateTime(1986,1,22), "AA1123 32311", "Иванов", "Иван", "Иванович",},
            new object[] { new DateTime(1982,1,22), "AA1123 32311", "Иванов", "Иван", "Иванович",},
            new object[] { new DateTime(1997,1,22), "AA1123 32311", "Иванов", "Иван", "Иванович",},
            new object[] { new DateTime(1955,1,22), "AA1123 32311", "Иванов", "Иван", "Иванович",},
            new object[] { new DateTime(1909,1,22), "AA1123 32311", "Иванов", "Иван", "Иванович",},
            new object[] { new DateTime(2000,1,22), "AA1123 32311", "Иванов", "Иван", "Иванович",},
        };

        [Theory]
        [MemberData(nameof(CorrectCreateClient))]
        public void CreateClientTheoryTest(
            DateTime birthday, string document, string surName,
            string firstName, string patronymic )
        {
            // Подготовка данных для тестирования
            var createClientRequest = new CreateClientRequest();
            createClientRequest.FirstName = firstName;
            createClientRequest.SurName = surName;
            createClientRequest.Patronymic = patronymic;
            createClientRequest.Birthday = birthday;
            createClientRequest.Document = document;

            _mockClientRepository.Setup(repository =>
                repository.Create(It.IsNotNull<Client>())).Returns(1).Verifiable();

            // Исполнение тестируемого метода
            var operationResult = _clientController.Create(createClientRequest);

            //Подготовка эталонного результата и проверка результата
            Assert.IsType<OkObjectResult>(operationResult.Result);
            var okObjectResult = (OkObjectResult)operationResult.Result;

            Assert.IsAssignableFrom<int>(okObjectResult.Value);
            _mockClientRepository.Verify(repository
                => repository.Create(It.IsNotNull<Client>()), Times.AtMostOnce());
        }

        public static object[][] IncorrectCreateClient =
        {
            new object[] { new DateTime(2010,1,22), "AA1123 32311", "Иванов", "Иван", "Иванович",},
            new object[] { new DateTime(3000,1,22), "AA1123 32311", "Иванов", "Иван", "Иванович",},
            new object[] { new DateTime(2000,1,22), "AA1123 32311", "Иванов", "", "Иванович",},
        };

        [Theory]
        [MemberData(nameof(IncorrectCreateClient))]
        public void CreateClientTheoryIncorrectTest(
            DateTime birthday, string document, string surName,
            string firstName, string patronymic)
        {
            // Подготовка данных для тестирования
            var createClientRequest = new CreateClientRequest();
            createClientRequest.FirstName = firstName;
            createClientRequest.SurName = surName;
            createClientRequest.Patronymic = patronymic;
            createClientRequest.Birthday = birthday;
            createClientRequest.Document = document;

            _mockClientRepository.Setup(repository =>
                repository.Create(It.IsNotNull<Client>())).Returns(1).Verifiable();

            // Исполнение тестируемого метода
            var operationResult = _clientController.Create(createClientRequest);

            //Подготовка эталонного результата и проверка результата
            Assert.IsType<OkObjectResult>(operationResult.Result);
            var okObjectResult = (OkObjectResult)operationResult.Result;


            _mockClientRepository.Verify(repository
                => repository.Create(It.IsNotNull<Client>()), Times.Never());
        }

    }
}


