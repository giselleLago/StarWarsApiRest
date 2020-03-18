using Autofac;
using VuelingExam.Domain.Entities.Aggregate;
using VuelingExam.Infrastructure.Repositories.Contracts;
using VuelingExam.Infrastructure.Repository.Implementations;

namespace VuelingExam.Aplication.Logic.AutofacModules
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder
                .RegisterType<RebeldRepository>()
                .As<IInfrastructureRepository<Rebeld>>()
                .InstancePerRequest();

            base.Load(builder);
        }
    }
}
