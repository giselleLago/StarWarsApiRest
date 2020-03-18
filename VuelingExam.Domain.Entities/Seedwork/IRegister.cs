namespace VuelingExam.Domain.Entities.Seedwork
{
    public interface IRegister<T>
    {
        T Register(T entity);
    }
}
