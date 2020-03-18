
namespace VuelingExam.Application.Logic.Contracts
{
    public interface IService<T>
    {
        bool Register(T dto);
    }
}
