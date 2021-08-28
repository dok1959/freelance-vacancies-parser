using System.Threading.Tasks;

namespace FreelanceParser.FSM
{
    public abstract class StateMachine<T, U, K> where T : IState<K> 
    {
        public bool IsInitialized { get; protected set; } = false;
        protected T _currentState;

        public abstract Task SetCurrentState(T state);

        public abstract Task Update(K data);

        public abstract void Initialize(U client, K data);
    }
}
