using AutoMapper;
using Core.DTOs;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Profiles
{
    public class TextMaterialProfile : Profile
    {
        public TextMaterialProfile()
        {
            CreateMap<TextMaterial, TextMaterialDTO>()
                .ForMember(tm => tm.Id, src => src.MapFrom(x => x.Id))
                .ForMember(tm => tm.Title, src => src.MapFrom(x => x.Title))
                .ForMember(tm => tm.Content, src => src.MapFrom(x => x.Content))
                .ForMember(tm => tm.DatePublished, src => src.MapFrom(x => x.DatePublished))
                .ForMember(tm => tm.CategoryTitle, src => src.MapFrom(x => x.TextMaterialCategory.Title))
                .ForMember(tm => tm.UserName, src => src.MapFrom(x => x.Author.UserName));

            CreateMap<CreateTextMaterialDTO, TextMaterial>();
        }
    }
}
