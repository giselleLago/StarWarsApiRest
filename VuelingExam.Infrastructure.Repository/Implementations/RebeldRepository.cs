using log4net;
using System;
using System.IO;
using VuelingExam.Domain.Entities.Aggregate;
using VuelingExam.Infrastructure.Repositories.Contracts;

namespace VuelingExam.Infrastructure.Repository.Implementations
{
    public class RebeldRepository : IInfrastructureRepository<Rebeld>
    {
        private readonly ILog logger = null;
        private readonly string FileName;

        public RebeldRepository()
        {
        }

        public RebeldRepository(ILog logger)
        {
            this.logger = logger;
            var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            FileName = Path.Combine(appData, "rebeld.txt");
        }


        public Rebeld Register(Rebeld entity)
        {
            logger.Info("Register started.");
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            File.AppendAllText(FileName, $"rebeld {entity.Name} on {entity.PlanetName} at {entity.DateTime}{Environment.NewLine}");
            return entity;
        }
    }
}
