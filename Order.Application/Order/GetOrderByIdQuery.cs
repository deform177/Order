using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Application.Order
{
    public class GetOrderByIdQuery : IRequest<Domains.Order.Order>
    {
        public int OrderId { get; set; }

        public GetOrderByIdQuery(int orderId)
        {
            if (orderId <= 0) throw new ArgumentOutOfRangeException(nameof(orderId));
            OrderId = orderId;
        }
    }
}
