using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Movies.Models
{
    public class Genre : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name field cannot be blank")]
        public string Name { get; set; }

        public virtual IList<Movie> Movies { get; set; }
    }
}
