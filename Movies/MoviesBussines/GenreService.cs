﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Movies.Business.DataTransferObjects;
using Movies.Business.Extensions;
using Movies.DataAccess.Repositories;
using Movies.Models;

namespace Movies.Business
{
    public class GenreService : IGenreService
    {
        private IGenreRepository genreRepository;
        private IMapper mapper;

        public GenreService(IGenreRepository genreRepository, IMapper mapper)
        {
            this.genreRepository = genreRepository;
            this.mapper = mapper;
        }

        public int AddGenre(AddNewGenreRequest request)
        {
            var newGenre = request.ConvertToGenre(mapper);
            genreRepository.Add(newGenre);
            return newGenre.Id;
        }

        public void DeleteGenre(int id)
        {
            genreRepository.Delete(id);
        }

        public IList<GenreListResponse> GetAllGenres()
        {
            var dtoList = genreRepository.GetAll().ToList();
            var result = dtoList.ConvertToListResponse(mapper);
            return result;

        }

        public GenreListResponse GetGenresById(int id)
        {
            Genre genre = genreRepository.GetById(id);
            return genre.ConvertFromEntity(mapper);
        }

        public int UpdateGenre(EditGenreRequest request)
        {
            var genre = request.ConvertToEntity(mapper);
            int id = genreRepository.Update(genre).Id;
            return id;
        }
    }
}
