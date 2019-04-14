using System.Threading.Tasks;
using App.Domain.Core.Commands;
using App.Domain.Core.Events;


namespace App.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
