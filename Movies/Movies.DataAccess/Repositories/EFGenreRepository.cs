using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Movies.DataAccess.Data;
using Movies.Models;

namespace Movies.DataAccess.Repositories
{
    public class EFGenreRepository : IGenreRepository
    {
        private MoviesDbContext db;

        public EFGenreRepository(MoviesDbContext moviesDbContext)
        {
            db = moviesDbContext;
        }

        public IList<Genre> GetWithCriteria(Expression<Func<Genre, bool>> criteria)
        {
            return db.Genres.Where(criteria).ToList();
        }

        public IList<Genre> GetWithCriteria(Func<Genre, bool> criteria)
        {
            return db.Genres.Where(criteria).ToList();
        }

        public Genre Add(Genre entity)
        {
            db.Genres.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            db.Genres.Remove(GetById(id));
            db.SaveChanges();
        }

        public void Delete(Genre entity)
        {
            throw new NotImplementedException();
        }

        public IList<Genre> GetAll()
        {
            return db.Genres.ToList();
        }

        public Genre GetById(int id)
        {
            return db.Genres.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public Genre Update(Genre genre)
        {
            // Update Genres SET Name = "Animation" WHERE Id = 7
            db.Entry(genre).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return genre;
        }
    }
}
