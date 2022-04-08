using MediatR;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Shop.Application.Articles.Commands.UpdateArticle
{
    public class UpdateArticleCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Producer { get; set; }
        public string Specifications { get; set; }
        public string Country { get; set; }
        public List<Order> Orders { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
    }
}