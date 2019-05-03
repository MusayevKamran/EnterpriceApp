using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infrastructure.Data.Context
{
    public class AppDbContextFactory : DesignTimeDbContextFactory<ShopDbContext>
    {}
    public class EventStoreSQLContextFactory : DesignTimeDbContextFactory<EventStoreSQLContext>
    {}
}
