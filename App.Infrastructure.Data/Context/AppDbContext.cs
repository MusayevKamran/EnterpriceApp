using System.Runtime.CompilerServices;
using App.Domain.Models;
using App.Infrastructure.Data.Mappings;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;


namespace App.Infrastructure.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Student> Students { get; set; }
    }
}
