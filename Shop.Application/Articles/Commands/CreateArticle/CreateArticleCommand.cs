using MediatR;
using System;

namespace Shop.Application.Articles.Commands.CreateArticle
{
    public class CreateArticleCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Producer { get; set; }
        public string Specifications { get; set; }
        public string Country { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
    }
}
