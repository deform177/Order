using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Application.Order
{
    public class OrderRollbackQuery : IRequest<bool>
    {
        public int OrderId { get; set; }

        public OrderRollbackQuery(int orderId)
        {
            if (orderId <= 0) throw new ArgumentOutOfRangeException(nameof(orderId));
            OrderId = orderId;
        }
    }
}
