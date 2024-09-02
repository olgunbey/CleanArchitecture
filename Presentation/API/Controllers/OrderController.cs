using Application.Features.Order.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> InsertOrder(InsertOrderCommand insertOrderCommand)
        {
          var order = await _mediator.Send(insertOrderCommand);

            return Ok(order);
        }
    }
}
