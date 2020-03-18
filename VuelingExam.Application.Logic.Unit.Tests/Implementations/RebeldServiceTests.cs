using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Autofac.Extras.Moq;
using log4net;
using VuelingExam.Application.Logic.DTOs;
using VuelingExam.Infrastructure.Repositories.Contracts;
using VuelingExam.Domain.Entities.Aggregate;
using System.Collections.Generic;

namespace VuelingExam.Application.Logic.Implementations.Unit.Tests
{
    [TestClass()]
    public class RebeldServiceTests
    {
        [TestMethod()]
        public void RegisterTest()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var rebeld = new Rebeld();
                mock.Mock<IInfrastructureRepository<Rebeld>>().Setup(repository => repository.Register(rebeld)).Returns(rebeld);
                mock.Mock<ILog>();
                var mockedService = mock.Create<IInfrastructureRepository<Rebeld>>();
                var mockedLog = mock.Create<ILog>();
                var rebeldService = new RebeldService(mockedLog, mockedService);
                var rebeldDto = new RebeldDto();
                rebeldDto.Names = new List<String>() { ("Pepe") };
                rebeldDto.PlanetName = "Saturno";
                var result = rebeldService.Register(rebeldDto);
                Assert.AreEqual(true, result);
            }
        }
    }
}