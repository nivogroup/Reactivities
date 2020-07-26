﻿using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Comments
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Comment, CommentDto>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(source => source.Author.UserName))
                .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(source => source.Author.DisplayName))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(source => 
                    source.Author.Photos.FirstOrDefault(x => x.isMain).Url));

        }
    }
}
