using MediatR;
using System;

namespace Shop.Application.Clients.Commands.DeleteClient
{
    public class DeleteClientCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
