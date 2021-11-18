using System.Threading;
using System.Threading.Tasks;
using DDD.Domain.Events;
using DDD.Domain.Events.Anuncio;
using MediatR;


namespace DDD.Domain.EventHandlers
{
    public class AnuncioEventHandler :
        INotificationHandler<AnuncioRegisteredEvent>,
        INotificationHandler<AnuncioUpdatedEvent>,
        INotificationHandler<AnuncioRemovedEvent>
    {
        public Task Handle(AnuncioUpdatedEvent message, CancellationToken cancellationToken)
        {

            return Task.CompletedTask;
        }

        public Task Handle(AnuncioRegisteredEvent message, CancellationToken cancellationToken)
        {

            return Task.CompletedTask;
        }

        public Task Handle(AnuncioRemovedEvent message, CancellationToken cancellationToken)
        {

            return Task.CompletedTask;
        }
    }
}
