using log4net;
using System.Web.Http;
using VuelingExam.Application.Logic.Contracts;
using VuelingExam.Application.Logic.DTOs;
using WebApplicaVuelingExam.Business.Facade.Contracts;

namespace VuelingExam.Business.Facade.Controllers
{
    public class RebeldController : ApiController, IController<RebeldDto>
    {
        readonly IService<RebeldDto> rebeldRepository = null;
        private readonly ILog logger = null;

        public RebeldController()
        {
        }

        public RebeldController(ILog logger, IService<RebeldDto> rebeldService)
        {
            this.rebeldRepository = rebeldService;
            this.logger = logger;
        }

        [HttpPost]
        public IHttpActionResult Register(RebeldDto entity)
        {
            logger.Info("Register started.");
            rebeldRepository.Register(entity);
            return Ok(true);
        }
    }
}