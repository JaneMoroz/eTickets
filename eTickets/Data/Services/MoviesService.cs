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

        public async Task DeleteMovieAsync(int id)
        {
            var dbMovie = await _context.Movies.FirstOrDefaultAsync(n => n.Id == id);

            if (dbMovie != null)
            {
                // Remove movie and actors ids from the joint table
                var existingActorsDb = _context.Actors_Movies.Where(n => n.MovieId == id).ToList();
                _context.Actors_Movies.RemoveRange(existingActorsDb);
                await _context.SaveChangesAsync();

                // Delete movie
                _context.Movies.Remove(dbMovie);
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

        public async Task UpdateMovieAsync(NewMovieVM movieData)
        {
            var dbMovie = await _context.Movies.FirstOrDefaultAsync(n => n.Id == movieData.Id);

            if (dbMovie != null)
            {
                dbMovie.Name = movieData.Name;
                dbMovie.Description = movieData.Description;
                dbMovie.Price = movieData.Price;
                dbMovie.ImageUrl = movieData.ImageUrl;
                dbMovie.CinemaId = movieData.CinemaId;
                dbMovie.StartDate = movieData.StartDate;
                dbMovie.EndDate = movieData.EndDate;
                dbMovie.MovieCategory = movieData.MovieCategory;
                dbMovie.DirectorId = movieData.DirectorId;
                await _context.SaveChangesAsync();
            }

            // Remove movie and actors ids from the joint table
            var existingActorsDb = _context.Actors_Movies.Where(n => n.MovieId == movieData.Id).ToList();
            _context.Actors_Movies.RemoveRange(existingActorsDb);
            await _context.SaveChangesAsync();

            // Add The Movie Actors
            foreach (var actorId in movieData.ActorIds)
            {
                var newMovieActor = new Actor_Movie
                {
                    MovieId = movieData.Id,
                    ActorId = actorId
                };

                await _context.Actors_Movies.AddAsync(newMovieActor);
            }

            await _context.SaveChangesAsync();
        }
    }
}
