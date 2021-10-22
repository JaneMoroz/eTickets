using eTickets.Data;
using eTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allMovies = await _service.GetAllAsync(x => x.Cinema);
            return View(allMovies.OrderByDescending(d => d.StartDate));
        }

        // GET: Movies/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var movieDetail = await _service.GetMovieByIdAsync(id);
            if (movieDetail == null)
                return View("NotFound");
            return View(movieDetail);
        }
    }
}
