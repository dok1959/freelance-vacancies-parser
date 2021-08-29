using System.Threading.Tasks;

namespace BotCore.Commands
{
    public interface ICommand<T, K>
    {
        public string Name { get; }

        public Task Execute(T data, K client);

        public bool Contains(T data);
    }
}
