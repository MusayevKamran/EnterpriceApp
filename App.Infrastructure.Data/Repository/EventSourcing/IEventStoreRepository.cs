﻿using App.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infrastructure.Data.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(int aggregateId);
    }
}
