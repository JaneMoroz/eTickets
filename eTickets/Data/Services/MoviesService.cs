using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        private readonly AppDbContext _context;
        public MoviesService(AppDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task AddNewMovieAsync(NewMovieVM newMovieData)
        {
            var newMovie = new Movie
            {
                Name = newMovieData.Name,
                Description = newMovieData.Description,
                Price = newMovieData.Price,
                ImageUrl = newMovieData.ImageUrl,
                CinemaId = newMovieData.CinemaId,
                StartDate = newMovieData.StartDate,
                EndDate = newMovieData.EndDate,
                MovieCategory = newMovieData.MovieCategory,
                DirectorId = newMovieData.DirectorId
            };

            await _context.Movies.AddAsync(newMovie);
            await _context.SaveChangesAsync();

            // Add The Movie Actors
            foreach (var actorId in newMovieData.ActorIds)
            {
                var newMovieActor = new Actor_Movie
                {
                    MovieId = newMovie.Id,
                    ActorId = actorId
                };

                await _context.Actors_Movies.AddAsync(newMovieActor);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetails = await _context.Movies
                .Include(c => c.Cinema)
                .Include(d => d.Director)
                .Include(am => am.Actors_Movies)
                .ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == id);

            return movieDetails;
        }

        public async Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues()
        {
            var response = new NewMovieDropdownsVM
            {
                Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync(),
                Directors = await _context.Directors.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
        }
    }
}
