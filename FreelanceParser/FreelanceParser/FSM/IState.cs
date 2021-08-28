using System.Threading.Tasks;

namespace FreelanceParser.FSM
{
    public interface IState<T>
    {
        public Task Enter();
        public Task Update(T data);
        public Task Exit();
    }
}