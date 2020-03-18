using Autofac.Extras.Moq;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VuelingExam.Domain.Entities.Aggregate;
using VuelingExam.Infrastructure.Repositories.Contracts;

namespace VuelingExam.Infrastructure.Repository.Implementations.Unit.Tests
{
    [TestClass()]
    public class RebeldRepositoryTests
    {
        [TestMethod()]
        public void RegisterTest()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var rebeld = new Rebeld();
                mock.Mock<IInfrastructureRepository<Rebeld>>().Setup(repository => repository.Register(rebeld)).Returns(rebeld);
                mock.Mock<ILog>();
                var mockedLog = mock.Create<ILog>();
                var rebeldRepository = new RebeldRepository(mockedLog);
                var result = rebeldRepository.Register(rebeld);
                Assert.AreEqual(rebeld, result);
            }
        }
    }
}