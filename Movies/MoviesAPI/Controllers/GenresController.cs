using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.API.Filters;
using Movies.Business;
using Movies.Business.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GenresController : ControllerBase
    {
        private IGenreService service;

        public GenresController(IGenreService genreService)
        {
            service = genreService;
        }
        [HttpGet]
        [AllowAnonymous]
        [ResponseCache(Duration = 300 )]
        public IActionResult Get()
        {
            var result = service.GetAllGenres();
            return Ok(new {genres = result, 
                   value = DateTime.Now.ToString()});
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        [ResponseCache(CacheProfileName = "List")]
        //[ResponseCache(Duration = 300, VaryByQueryKeys = new []{ "id" })]
        public IActionResult GetById(int id)
        {
            var genreListResponse = service.GetGenresById(id);
            if (genreListResponse != null)
            {
                return Ok(new { result = genreListResponse, cacheTime = DateTime.Now.ToString() });
            }
            return NotFound();
        }
        [HttpPost]
        [Authorize(Roles = "Admin,Editor")]
        public IActionResult AddGenre(AddNewGenreRequest request)
        {
            if (ModelState.IsValid)
            {
                int genreId = service.AddGenre(request);
                return CreatedAtAction(nameof(GetById), routeValues: new {id = genreId}, value: null);
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id}")]
        [GenreExists]
        public IActionResult UpdateGenre(int id, EditGenreRequest request)
        {
            //var isExisting = service.GetGenresById(request.Id);
            //if (isExisting == null)
            //{
            //    return NotFound();
            //}
            if (ModelState.IsValid)
            {
                int newItemId = service.UpdateGenre(request);
                return Ok();
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        [GenreExists]
        public IActionResult Delete(int id)
        {
            //var isExisting = service.GetGenresById(id);
            //if (isExisting == null)
            //{
            //    return NotFound();
            //}
            service.DeleteGenre(id);
            return Ok();
        }
        
    }
}
