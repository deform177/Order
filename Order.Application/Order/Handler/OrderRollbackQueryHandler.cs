using MediatR;
using Order.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Order.Application.Order.Handler
{
    class OrderRollbackQueryHandler : IRequestHandler<OrderRollbackQuery, bool>
    {
        private readonly IOrderRepository _repository;

        public OrderRollbackQueryHandler(IOrderRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public Task<bool> Handle(OrderRollbackQuery request, CancellationToken cancellationToken)
        {
            return _repository.RollbackOrderById(request.OrderId);
        }
    }
}
