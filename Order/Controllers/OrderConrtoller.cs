using MediatR;
using Microsoft.AspNetCore.Mvc;
using Order.Application.Order;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Order.WebApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class OrderConrtoller : Controller
    {
        private readonly IMediator _mediator;

        public OrderConrtoller(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        [HttpGet("order/{id}")]
        public async Task<ActionResult> Get([FromRoute, Required] int id,
       CancellationToken cancellationToken)
        {
            var order = await _mediator.Send(new GetOrderByIdQuery(id), cancellationToken);
            return Ok(order);
        }

        [HttpGet("order/{id}/rollback")]
        public async Task<ActionResult> OrderRollback([FromRoute, Required] int id,
        CancellationToken cancellationToken)
        {
            var order = await _mediator.Send(new OrderRollbackQuery(id), cancellationToken);
            return Ok(order);
        }
    }
}
