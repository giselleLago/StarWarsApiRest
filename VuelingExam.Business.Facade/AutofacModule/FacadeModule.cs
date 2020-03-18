using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using VuelingExam.Aplication.Logic.AutofacModules;
using VuelingExam.Application.Logic.Contracts;
using VuelingExam.Application.Logic.DTOs;
using VuelingExam.Application.Logic.Implementations;

namespace VuelingExam.Business.Facade.AutofacModules
{
    public class FacadeModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder
                .RegisterType<RebeldService>()
                .As<IService<RebeldDto>>()
                .InstancePerRequest();

            builder.RegisterModule(new LoggingModule());
            builder.RegisterModule(new ServiceModule());
            base.Load(builder);
        }
    }
}