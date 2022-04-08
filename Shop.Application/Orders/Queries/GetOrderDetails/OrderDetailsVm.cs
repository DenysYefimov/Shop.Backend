using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Shop.Application.Orders.Queries.GetOrderDetails
{
    public class OrderDetailsVm : IMapWith<Order>
    {
        public Guid Id { get; set; }
        public Client Client { get; set; }
        public List<Article> Articles { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? SendingDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderDetailsVm>()
                .ForMember(orderVm => orderVm.Id,
                    opt => opt.MapFrom(order => order.Id))
                .ForMember(orderVm => orderVm.Client,
                    opt => opt.MapFrom(order => order.Client))
                .ForMember(orderVm => orderVm.Articles,
                    opt => opt.MapFrom(order => order.Articles))
                .ForMember(orderVm => orderVm.OrderDate,
                    opt => opt.MapFrom(order => order.OrderDate))
                .ForMember(orderVm => orderVm.SendingDate,
                    opt => opt.MapFrom(order => order.SendingDate));
        }
    }
}
