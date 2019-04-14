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
        public IList<StoredEvent> All(Guid aggregateId)
        {
            return (from e in _context.StoredEvent
                    where e.AggregateId == aggregateId
                    select e).ToList();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Store(StoredEvent theEvent)
        {
            throw new NotImplementedException();
        }
    }
}
