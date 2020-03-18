using log4net;
using System;
using System.Collections.Generic;
using VuelingExam.Application.Logic.Contracts;
using VuelingExam.Application.Logic.DTOs;
using VuelingExam.Domain.Entities.Aggregate;
using VuelingExam.Infrastructure.Repositories.Contracts;

namespace VuelingExam.Application.Logic.Implementations
{
    public class RebeldService : IService<Rebeld>
    {
        readonly IInfrastructureRepository<Rebeld> rebeldRepository = null;
        private readonly ILog logger = null;

        public RebeldService()
        {
        }

        public RebeldService(ILog logger, IInfrastructureRepository<Rebeld> rebeldRepository)
        {
            this.rebeldRepository = rebeldRepository;
            this.logger = logger;
        }

        public Rebeld Register(Rebeld entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            entity.DateTime = DateTime.Now;
            return rebeldRepository.Register(entity);
        }

        private IEnumerable<Rebeld> ToRebeld(RebeldDto rebeldDto)
        {
            var rebeldList = new List<Rebeld>();
            var rebeldNames = rebeldDto.Name;
            foreach (var item in rebeldNames)
            {
                rebeldList.Add(new Rebeld { Name = item, PlanetName = rebeldDto.PlanetName });
            }
            return rebeldList;
        }
    }
}
