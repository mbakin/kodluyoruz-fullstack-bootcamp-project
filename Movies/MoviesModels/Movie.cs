using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Movies.Models
{
    public class Movie : IEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Movie name cannot be empty.")]
        [MinLength(2,ErrorMessage = "Movie name must be at least 2 characters.")]
        [MaxLength(200,ErrorMessage = "Movie name must be a maximum of 2 characters.")]
        public string Title { get; set; }
        
        public decimal?  Price { get; set; }
        public string PosterPath { get; set; }

        public int? GenreId { get; set; }
        
        // Navigation Property
        public virtual Genre Genre { get; set; }

        public virtual IList<MovieActor> Actors { get; set; }


    }
}
