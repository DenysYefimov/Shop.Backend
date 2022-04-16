using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shop.Domain.Entities;
using Shop.Persistence;
using System;
using System.Security.Claims;

namespace Shop.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => 
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        private ShopDbContext _shopDbContext;
        protected ShopDbContext ShopDbContext =>
            _shopDbContext ??= HttpContext.RequestServices.GetService<ShopDbContext>();

        internal Client Client => !User.Identity.IsAuthenticated
            ? null
            : _shopDbContext.Clients.Find(
                Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value));
    }
}
