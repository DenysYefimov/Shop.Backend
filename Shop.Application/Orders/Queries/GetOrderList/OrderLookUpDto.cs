using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Shop.Application.Orders.Queries.GetOrderList
{
    public class OrderLookUpDto : IMapWith<Order>
    {
        public Guid Id { get; set; }
        public List<Article> Articles { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderLookUpDto>()
                .ForMember(orderDto => orderDto.Id,
                    opt => opt.MapFrom(order => order.Id))
                .ForMember(orderDto => orderDto.Articles,
                    opt => opt.MapFrom(order => order.Articles));
        }
    }
}
