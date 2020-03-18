using log4net;
using System;
using System.Collections.Generic;
using VuelingExam.Application.Logic.Contracts;
using VuelingExam.Application.Logic.DTOs;
using VuelingExam.Domain.Entities.Aggregate;
using VuelingExam.Infrastructure.Repositories.Contracts;

namespace VuelingExam.Application.Logic.Implementations
{
    public class RebeldService : IService<RebeldDto>
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

        public bool Register(RebeldDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }
            var rebeld = ToRebelds(dto);
            foreach (var item in rebeld)
            {
                rebeldRepository.Register(item);
            }
            return true;
        }

        private IEnumerable<Rebeld> ToRebelds(RebeldDto rebeldDto)
        {
            var rebeldList = new List<Rebeld>();
            var rebeldNames = rebeldDto.Names;
            foreach (var item in rebeldNames)
            {
                rebeldList.Add(new Rebeld { Name = item, PlanetName = rebeldDto.PlanetName, DateTime = DateTime.Now });
            }
            return rebeldList;
        }
    }
}
