using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Movies.DataAccess.Repositories
{
    public class FakeGenreRepository : IGenreRepository
    {
        public IList<Genre> GetWithCriteria(Func<Genre, bool> criteria)
        {
            throw new NotImplementedException();
        }

        public Genre Add(Genre entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Genre entity)
        {
            throw new NotImplementedException();
        }

        public IList<Genre> GetAll()
        {
            return new List<Genre>
            {
                new Genre {Id = 1, Name = "Science Fiction"},
                new Genre {Id = 2, Name = "Action"},
                new Genre {Id = 3, Name = "Biography"},
                new Genre {Id = 4, Name = "Comedy"},

            };
        }

        public Genre GetById(int id)
        {
            throw new NotImplementedException();
        }


        public Genre Update(Genre genre)
        {
            throw new NotImplementedException();
        }
    }
}
