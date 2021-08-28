using System.Threading.Tasks;

namespace FreelanceParser.FSM
{
    public abstract class StateMachine<T>
    {
        protected IState<T> _currentState;

        public abstract Task SetCurrentState(IState<T> state, T data);

        public abstract Task Update(T data);
    }
}
