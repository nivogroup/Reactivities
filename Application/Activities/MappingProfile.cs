using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Activities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Activity, ActivityDto>();
            CreateMap<UserActivity, AttendeeDto>()
                .ForMember(dest => dest.Username, option => option.MapFrom(source => source.AppUser.UserName))
                .ForMember(dest => dest.DisplayName, option => option.MapFrom(source => source.AppUser.DisplayName));
        }
    }
}
