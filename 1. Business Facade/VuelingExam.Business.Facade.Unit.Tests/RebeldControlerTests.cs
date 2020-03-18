using Autofac.Extras.Moq;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Web.Http.Results;
using VuelingExam.Application.Logic.Contracts;
using VuelingExam.Application.Logic.DTOs;
using VuelingExam.Business.Facade.Controllers;

namespace VuelingExam.Business.Facade.Unit.Tests
{
    [TestClass()]
    public class RebeldControllerTests
    {
        [TestMethod()]
        public void RegisterTest()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var rebeldDto = new RebeldDto
                {
                    Names = new List<String>() { ("Pepe") },
                    PlanetName = "Saturno"
                };
                mock.Mock<IService<RebeldDto>>().Setup(repository => repository.Register(rebeldDto)).Returns(true);
                mock.Mock<ILog>();
                var mockedService = mock.Create<IService<RebeldDto>>();
                var mockedLog = mock.Create<ILog>();
                var controller = new RebeldController(mockedLog, mockedService);
                var result = controller.Register(rebeldDto);
                var response = result as OkNegotiatedContentResult<RebeldDto>;
                Assert.AreEqual(rebeldDto, response.Content);
            }
        }
    }
}
