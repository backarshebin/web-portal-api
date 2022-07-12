using System;
using Microsoft.EntityFrameworkCore;
using portal_domain;

namespace portal_dal
{
    public class PortalDbContext : DbContext
    {

        public PortalDbContext(DbContextOptions<PortalDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var path = Directory.GetCurrentDirectory();
            options.UseSqlite($"Data Source={System.IO.Path.Join(path, "/SqlliteDB/portal.db")}");


        }
        public DbSet<User> Users { get; set; }

    }
}
