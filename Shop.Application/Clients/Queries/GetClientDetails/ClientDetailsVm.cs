using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Shop.Application.Clients.Queries.GetClientDetails
{
    public class ClientDetailsVm : IMapWith<Client>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Order> Orders { get; set; }
        public DateTime Birthday { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Client, ClientDetailsVm>()
                .ForMember(clientVm => clientVm.Id,
                    opt => opt.MapFrom(client => client.Id))
                .ForMember(clientVm => clientVm.FirstName,
                    opt => opt.MapFrom(client => client.FirstName))
                .ForMember(clientVm => clientVm.LastName,
                    opt => opt.MapFrom(client => client.LastName))
                .ForMember(clientVm => clientVm.Patronymic,
                    opt => opt.MapFrom(client => client.Patronymic))
                .ForMember(clientVm => clientVm.Address,
                    opt => opt.MapFrom(client => client.Address))
                .ForMember(clientVm => clientVm.PhoneNumber,
                    opt => opt.MapFrom(client => client.PhoneNumber))
                .ForMember(clientVm => clientVm.Orders,
                    opt => opt.MapFrom(client => client.Orders))
                .ForMember(clientVm => clientVm.Birthday,
                    opt => opt.MapFrom(client => client.Birthday));
        }
    }
}
