using AutoMapper;
using LGG.Core.Dtos;
using LGG.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace LGG.Persistence
{
    public class MapperConfig
    {
        public static void Config()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ArticleDto, Article>().ReverseMap();
                cfg.CreateMap<CategoryDto, Category>().ReverseMap();
                cfg.CreateMap<ContactDto, Contact>().ReverseMap();
                cfg.CreateMap<ExcerptDto, Excerpt>().ReverseMap();
                cfg.CreateMap<PostTagDto, PostTag>().ReverseMap();
                cfg.CreateMap<TagDto, Tag>().ReverseMap();
                cfg.CreateMap<Post, PostDto>()
                 .ForMember(dto => dto.Tags, opt => opt.MapFrom(x => x.PostTags.Select(t => t.Tag))).ReverseMap();
                cfg.CreateMap<PostTag, TagDto>().ReverseMap();
                cfg.CreateMap<List<Post>, List<PostDto>>().ReverseMap();
                cfg.CreateMap<CompanyDto, Company>().ReverseMap();
            });
        }
    }
}
