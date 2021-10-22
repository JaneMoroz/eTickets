using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Base
{
    public interface IEntityBaseRepository<T> where T: class, IEntityBase, new()
    {
        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id">entity's Id</param>
        /// <returns></returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Add a new entity
        /// </summary>
        /// <param name="entity">entity's model</param>
        Task AddAsync(T entity);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="id">entity's id</param>
        /// <param name="newEntity"></param>
        /// <returns></returns>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="id">entity's id</param>
        Task DeleteAsync(int id);
    }
}
