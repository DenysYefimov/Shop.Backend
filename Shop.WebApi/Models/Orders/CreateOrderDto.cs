using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Application.Orders.Commands.CreateOrder;
using Shop.Domain.Entities;
using System.Collections.Generic;

namespace Shop.WebApi.Models
{
    public class CreateOrderDto : IMapWith<CreateOrderCommand>
    {
        public List<Article> Articles { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateOrderCommand, CreateOrderDto>()
                .ForMember(createOrderDto => createOrderDto.Articles,
                    opt => opt.MapFrom(createOrderCommand => createOrderCommand.Articles));
        }
    }
}
