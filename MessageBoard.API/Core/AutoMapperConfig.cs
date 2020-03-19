using AutoMapper;
using MessageBoard.API.Models;
using MessageBoard.API.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageBoard.API.Core
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<CreatePostVM, Post>()
                .ForMember(dest => dest.PostText, opt => opt.MapFrom(src => src.Text))
                .AfterMap((src, dest) =>
                {
                    dest.PostDate = DateTime.Now.ToUniversalTime();
                });

          
        }
    }
}
