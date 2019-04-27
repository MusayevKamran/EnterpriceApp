using System;
using System.Collections.Generic;
using System.Linq;
using App.Domain.Core.Events;
using App.Infrastructure.Data.Context;

namespace App.Infrastructure.Data.Repository.EventSourcing
{
    public class EventStoreSQLRepository : IEventStoreRepository
    {
        private readonly EventStoreSQLContext _context;
        public EventStoreSQLRepository(EventStoreSQLContext context)
        {
            _context = context;
        }
        public IList<StoredEvent> All(int aggregateId)
        {
            return (from e in _context.StoredEvent
                    where e.AggregateId == aggregateId
                    select e).ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Store(StoredEvent theEvent)
        {
            _context.StoredEvent.Add(theEvent);
            _context.SaveChanges();
        }
    }
}
