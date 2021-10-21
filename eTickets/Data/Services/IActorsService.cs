﻿using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public interface IActorsService
    {
        /// <summary>
        /// Get all actors
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Actor>> GetAllAsync();

        /// <summary>
        /// Get an actor by id
        /// </summary>
        /// <param name="id">Actor's Id</param>
        /// <returns></returns>
        Task<Actor> GetByIdAsync(int id);

        /// <summary>
        /// Add a new actor
        /// </summary>
        /// <param name="actor">Actor's model</param>
        Task AddAsync(Actor actor);

        /// <summary>
        /// Update actor
        /// </summary>
        /// <param name="id">Actor's id</param>
        /// <param name="newActor"></param>
        /// <returns></returns>
        Task<Actor> UpdateAsync(Actor newActor);

        /// <summary>
        /// Delete actor
        /// </summary>
        /// <param name="id">Actor's id</param>
        Task DeleteAsync(int id);
    }
}
