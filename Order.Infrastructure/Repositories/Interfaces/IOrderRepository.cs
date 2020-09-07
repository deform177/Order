using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<Domains.Order.Order> GetById(int id);
        Task<bool> RollbackOrderById(int id);
    }
}
