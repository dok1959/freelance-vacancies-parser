using System.Threading.Tasks;

namespace Bot.Core.FSM
{
    public interface IState<T>
    {
        public Task Enter();
        public Task Update(T data);
        public Task Exit();
    }
}