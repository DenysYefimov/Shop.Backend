using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Domain.Entities;
using System;

namespace Shop.Application.Articles.Queries.GetArticleList
{
    public class ArticleLookUpDto : IMapWith<Article>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Article, ArticleLookUpDto>()
                .ForMember(articleDto => articleDto.Id,
                    opt => opt.MapFrom(article => article.Id))
                .ForMember(articleDto => articleDto.Name,
                    opt => opt.MapFrom(article => article.Name));
        }
    }
}