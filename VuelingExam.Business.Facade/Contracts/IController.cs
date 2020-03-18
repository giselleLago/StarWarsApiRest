using System.Web.Http;

namespace WebApplicaVuelingExam.Business.Facade.Contracts
{
    public interface IController<T>
    {
        IHttpActionResult Register(T entity);
    }
}