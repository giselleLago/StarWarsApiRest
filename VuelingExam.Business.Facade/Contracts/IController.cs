using System.Web.Http;

namespace WebApplicaVuelingExam.Business.Facade.Contracts
{
    public interface IController<T>
    {
        IHttpActionResult Get();
        IHttpActionResult Create(T entity);
        IHttpActionResult Update(int id, T entity);
        IHttpActionResult Delete(int id);
    }
}