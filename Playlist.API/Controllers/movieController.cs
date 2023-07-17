
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Playlist.API.Models;
using Playlist.API.Services;
namespace Playlist.API.Controllers
{
    [Route("playlist")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MoviesService _movieService;

        public MoviesController(MoviesService moviesService)
        {
            _movieService = moviesService;
        }

        [HttpGet]
        public ActionResult<List<Movie>> Get() =>
            _movieService.Get();

        [HttpGet("{id:length(24)}", Name = "GetMovie")]
        public ActionResult<Movie> Get(string id)
        {
            var movie = _movieService.Get(id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        [HttpPost]
        public ActionResult<Movie> Create(Movie movie)
        {
            _movieService.Create(movie);

            return CreatedAtRoute("GetMovie", new { id = movie.Id.ToString() }, movie);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Movie movieIn)
        {
            var movie = _movieService.Get(id);

            if (movie == null)
            {
                return NotFound();
            }

            _movieService.Update(id, movieIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var movie = _movieService.Get(id);

            if (movie == null)
            {
                return NotFound();
            }

            _movieService.Delete(movie.Id);

            return NoContent();
        }
    }
}