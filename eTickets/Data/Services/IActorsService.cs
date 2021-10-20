using eTickets.Models;
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
        Task<IEnumerable<Actor>> GetAll();

        /// <summary>
        /// Get an actor by id
        /// </summary>
        /// <param name="id">Actor's Id</param>
        /// <returns></returns>
        Actor GetById(int id);

        /// <summary>
        /// Add a new actor
        /// </summary>
        /// <param name="actor">Actor's model</param>
        void Add(Actor actor);

        /// <summary>
        /// Update actor
        /// </summary>
        /// <param name="id">Actor's id</param>
        /// <param name="newActor"></param>
        /// <returns></returns>
        Actor Update(int id, Actor newActor);

        /// <summary>
        /// Delete actor
        /// </summary>
        /// <param name="id">Actor's id</param>
        void Delete(int id);
    }
}
