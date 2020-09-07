using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Infrastructure.Repositories
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options)
           : base(options)
        {
        }

        public DbSet<Domains.Order.Order> Orders { get; set; }
        public DbSet<Domains.Order.User> Users { get; set; }
    }
}
