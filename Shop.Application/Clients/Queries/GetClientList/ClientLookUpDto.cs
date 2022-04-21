using AutoMapper;
using Shop.Application.Clients.Queries.GetClientDetails;
using Shop.Application.Common.Mappings;
using Shop.Domain.Entities;
using System;

namespace Shop.Application.Clients.Queries.GetClientList
{
    public class ClientLookUpDto : IMapWith<Client>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }

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
                    opt => opt.MapFrom(client => client.Patronymic));
        }
    }
}
