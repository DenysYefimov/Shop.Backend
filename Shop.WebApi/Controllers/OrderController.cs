using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Orders.Commands.CreateOrder;
using Shop.Application.Orders.Commands.DeleteOrder;
using Shop.Application.Orders.Commands.UpdateOrder;
using Shop.Application.Orders.Queries.GetOrderDetails;
using Shop.Application.Orders.Queries.GetOrderList;
using Shop.WebApi.Models;
using System;
using System.Threading.Tasks;

namespace Shop.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class OrderController : BaseController
    {
        private readonly IMapper _mapper;
        public OrderController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Gets the list of orders
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /order
        /// </remarks>
        /// <returns>Returns OrderListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<OrderListVm>> GetAll()
        {
            var query = new GetOrderListQuery
            {
                Client = Client
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the order by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /order/D34D349E-43B8-429E-BCA4-793C932FD580
        /// </remarks>
        /// <param name="id">Order id (guid)</param>
        /// <returns>Returns OrderDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user in unauthorized</response>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<OrderDetailsVm>> Get(Guid id)
        {
            var query = new GetOrderDetailsQuery
            {
                Client = Client,
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Creates the order
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /order
        /// {
        ///     articles: List of Article instances
        /// }
        /// </remarks>
        /// <param name="createOrderDto">CreateOrderDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateOrderDto createOrderDto)
        {
            var command = _mapper.Map<CreateOrderCommand>(createOrderDto);
            command.Client = Client;
            var orderId = await Mediator.Send(command);
            return Ok(orderId);
        }

        /// <summary>
        /// Updates the order
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /order
        /// {
        ///     articles: List of Article instances
        /// }
        /// </remarks>
        /// <param name="updateOrderDto">UpdateOrderDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromBody] UpdateOrderDto updateOrderDto)
        {
            var command = _mapper.Map<UpdateOrderCommand>(updateOrderDto);
            command.Client = Client;
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Deletes the order by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /order/88DEB432-062F-43DE-8DCD-8B6EF79073D3
        /// </remarks>
        /// <param name="id">Id of the order (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteOrderCommand
            {
                Id = id,
                Client = Client
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
