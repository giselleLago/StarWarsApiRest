using Autofac;
using Autofac.Core;

namespace VuelingExam.Test.Framework
{
    public class IoCSuportedTest<TModule> where TModule : IModule, new()
    {
        private readonly IContainer container;
        public IoCSuportedTest()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new TModule());
            container = builder.Build();
        }

        protected TEntity Resolve<TEntity>()
        {
            return container.Resolve<TEntity>();
        }

        protected void ShutdownIoC()
        {
            container.Dispose();
        }
    }
}
