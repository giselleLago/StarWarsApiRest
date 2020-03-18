using Autofac;
using System.Web.Http;
using Autofac.Integration.WebApi;
using VuelingExam.Business.Facade.AutofacModules;

namespace VuelingExam.Business.Facade.App_Start
{
    public class AutofacConfig
    {
        protected AutofacConfig() { }
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new FacadeModule());
            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
            return container;
        }
    }
}