using Microsoft.EntityFrameworkCore;
using Order.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _context;

        public OrderRepository(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<Domains.Order.Order> GetById(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<bool> RollbackOrderById(int id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(q => q.Id == id);
            return order.OrderRollback();

        }
    }
}
