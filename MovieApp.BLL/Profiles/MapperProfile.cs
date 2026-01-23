using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MovieApp.BLL.Dtos.Director_Dtos;
using MovieApp.BLL.Dtos.MovieDtos;
using MovieApp.DAL.Models;

namespace MovieApp.BLL.Profiles
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Director, DirectorReturnDto>()
                .ForMember(dest=>dest.Movies, opt=>opt.MapFrom(src=>src.Movies != null ? src.Movies.Select(m=>m.Title).ToList() :new List<string>()));
            CreateMap<DirectorCreateDto, Director>();
            CreateMap<DirectorUpdateDto, Director>();
            CreateMap<Movie,MovieReturnDto>();
            CreateMap<MovieCreateDto, Movie>();
            CreateMap<MovieUpdateDto, Movie>();

        }


    }
}
