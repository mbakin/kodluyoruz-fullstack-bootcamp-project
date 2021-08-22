using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Movies.Business.DataTransferObjects;
using Movies.Models;

namespace Movies.Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Genre, GenreListResponse>().ReverseMap();
            CreateMap<Genre, AddNewGenreRequest>().ReverseMap();
            CreateMap<Genre, EditGenreRequest>().ReverseMap();
        }
    }
}
