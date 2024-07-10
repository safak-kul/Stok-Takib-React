using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StokReact.Entities;
using System.Collections.Generic;

namespace StokReact.Dal
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        protected readonly IConfiguration Configuration;
        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
    }
}