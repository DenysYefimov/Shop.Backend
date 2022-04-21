using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Shop.Application.Articles.Queries.GetArticleDetails
{
    public class ArticleDetailsVm : IMapWith<Article>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Producer { get; set; }
        public string Specifications { get; set; }
        public string Country { get; set; }
        public ICollection<Order> Orders { get; set; }
        public double Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Article, ArticleDetailsVm>()
                .ForMember(articleVm => articleVm.Name,
                    opt => opt.MapFrom(article => article.Name))
                .ForMember(articleVm => articleVm.Producer,
                    opt => opt.MapFrom(article => article.Producer))
                .ForMember(articleVm => articleVm.Specifications,
                    opt => opt.MapFrom(article => article.Specifications))
                .ForMember(articleVm => articleVm.Id,
                    opt => opt.MapFrom(article => article.Id))
                .ForMember(articleVm => articleVm.Country,
                    opt => opt.MapFrom(article => article.Country))
                .ForMember(articleVm => articleVm.Orders,
                    opt => opt.MapFrom(article => article.Orders))
                .ForMember(articleVm => articleVm.Price,
                    opt => opt.MapFrom(article => article.Price));
        }
    }
}
