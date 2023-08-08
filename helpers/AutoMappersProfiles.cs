using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.entities;
using API.extensions;
using AutoMapper;

namespace API.helpers
{
    public class AutoMappersProfiles : Profile
    {
        public AutoMappersProfiles() 
        
        {
            CreateMap<AppUser, MemberDto>()
            .ForMember(dest => dest.PhotoUrl,
             opt => opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url))
             .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalcuateAge()));
            CreateMap<Photo, PhotoDto>();       
            CreateMap<MemberUpdateDto, AppUser>();     
        }
    }
}