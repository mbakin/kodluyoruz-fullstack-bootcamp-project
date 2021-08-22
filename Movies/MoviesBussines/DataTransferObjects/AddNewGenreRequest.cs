using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Movies.Business.DataTransferObjects
{
    public class AddNewGenreRequest
    {
        [Required(ErrorMessage = "You didn't specify the type name.")]
        public string Name { get; set; }
    }
}
