using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Movies.Models;

namespace Movies.DataAccess.Data
{
    public class MoviesDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }

        public MoviesDbContext()
        {
            
        }

        public MoviesDbContext(DbContextOptions<MoviesDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .Property(m => m.Title)
                .IsRequired();

            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Genre)
                .WithMany(g => g.Movies)
                .HasForeignKey(m => m.GenreId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MovieActor>()
                .HasKey(ma => new {ma.ActorId, ma.MovieId});

            modelBuilder.Entity<MovieActor>()
                .HasOne(ma => ma.Movie)
                .WithMany(movie => movie.Actors)
                .HasForeignKey(ma => ma.ActorId);

            modelBuilder.Entity<MovieActor>()
                .HasOne(ma => ma.Actor)
                .WithMany(actor => actor.Movies)
                .HasForeignKey(ma => ma.MovieId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
