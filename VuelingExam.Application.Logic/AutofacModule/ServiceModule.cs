using Autofac;
using VuelingExam.Domain.Entities;
using VuelingExam.Infrastructure.Repositories.Contracts;
using VuelingExam.Infrastructure.Repositories.Implementations;

namespace VuelingExam.Aplication.Logic.AutofacModules
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder
                .RegisterType<T>()
                .As<IInfrastructureRepository<T>>()
                .InstancePerRequest();

            base.Load(builder);
        }
    }
}
