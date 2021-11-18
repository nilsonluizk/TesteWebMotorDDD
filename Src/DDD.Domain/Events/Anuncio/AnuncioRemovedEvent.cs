using System;
using DDD.Domain.Core.Events;

namespace DDD.Domain.Events.Anuncio
{
    public class AnuncioRemovedEvent : Event
    {
        public AnuncioRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}
