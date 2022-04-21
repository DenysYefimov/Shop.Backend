using AutoMapper;
using Shop.Application.Articles.Commands.CreateArticle;
using Shop.Application.Common.Mappings;

namespace Shop.WebApi.Models.Articles
{
    public class CreateArticleDto : IMapWith<CreateArticleCommand>
    {
        public string Name { get; set; }
        public string Producer { get; set; }
        public string Specifications { get; set; }
        public string Country { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateArticleCommand, CreateArticleDto>()
                .ForMember(createArticleDto => createArticleDto.Name,
                    opt => opt.MapFrom(createArticleCommand => createArticleCommand.Name))
                .ForMember(createArticleDto => createArticleDto.Producer,
                    opt => opt.MapFrom(createArticleCommand => createArticleCommand.Producer))
                .ForMember(createArticleDto => createArticleDto.Specifications,
                    opt => opt.MapFrom(createArticleCommand => createArticleCommand.Specifications))
                .ForMember(createArticleDto => createArticleDto.Country,
                    opt => opt.MapFrom(createArticleCommand => createArticleCommand.Country))
                .ForMember(createArticleDto => createArticleDto.Price,
                    opt => opt.MapFrom(createArticleCommand => createArticleCommand.Price))
                .ForMember(createArticleDto => createArticleDto.Amount,
                    opt => opt.MapFrom(createArticleCommand => createArticleCommand.Amount));
        }
    }
}
