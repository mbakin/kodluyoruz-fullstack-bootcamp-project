using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Movies.Models
{
    public class Actor : IEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Actor name cannot be empty.")]
        [MinLength(2, ErrorMessage = "Actor name must be at least 2 characters.")]
        [MaxLength(200, ErrorMessage = "Actor name must be a maximum of 2 characters.")]
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Notes { get; set; }

        public virtual  IList<MovieActor> Movies { get; set; }
    }
}
