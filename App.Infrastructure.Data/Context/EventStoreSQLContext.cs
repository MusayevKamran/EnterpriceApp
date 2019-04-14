using App.Domain.Core.Events;
using App.Infrastructure.Data.Mappings;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;


namespace App.Infrastructure.Data.Context
{
    public class EventStoreSQLContext : DbContext
    {
        public EventStoreSQLContext(DbContextOptions<EventStoreSQLContext> options) : base(options)
        {
        }

        public DbSet<StoredEvent> StoredEvent { get; set; }

    }
}
