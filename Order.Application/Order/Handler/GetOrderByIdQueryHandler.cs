using MediatR;
using Order.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Order.Application.Order.Handler
{
    class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Domains.Order.Order>
    {
        private readonly IOrderRepository _repository;

        public GetOrderByIdQueryHandler(IOrderRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }


        public Task<Domains.Order.Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetById(request.OrderId);
        }
    }
}
