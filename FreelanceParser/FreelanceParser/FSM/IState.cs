using System.Threading.Tasks;

namespace FreelanceParser.FSM
{
    public interface IState<T>
    {
        public Task Enter(T data);
        public Task Update(T data);
        public Task Exit(T data);
    }
}