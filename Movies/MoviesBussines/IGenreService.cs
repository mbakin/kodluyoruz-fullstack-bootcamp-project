using System;
using System.Collections.Generic;
using System.Text;
using Movies.Business.DataTransferObjects;
using Movies.Models;

namespace Movies.Business
{
    public interface IGenreService
    {
        IList<GenreListResponse> GetAllGenres();
        
        // the id of the last entity added will be returned
        int AddGenre(AddNewGenreRequest request);
        GenreListResponse GetGenresById(int id);
        int UpdateGenre(EditGenreRequest request);
        void DeleteGenre(int id);
    }
}
