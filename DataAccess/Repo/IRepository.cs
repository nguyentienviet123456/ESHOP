using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repo
{
    public interface IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Gets a table
        /// </summary>
        IQueryable<T> Table { get; }

        /// <summary>
        /// Get entity by identifier
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        T GetById(object Id);

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity"></param>
        void Insert(T entity);

        /// <summary>
        /// Insert entities
        /// </summary>
        /// <param name="entities"></param>
        void Insert(IEnumerable<T> entities);

        /// <summary>
        /// Attach entity.
        /// </summary>
        /// <param name="entity"></param>
        void Attach(T entity);

        /// <summary>
        /// Attach entities.
        /// </summary>
        /// <param name="entities"></param>
        void Attach(IEnumerable<T> entities);

        /// <summary>
        /// Delete entity.
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);

        /// <summary>
        /// Delete entities.
        /// </summary>
        /// <param name="entities"></param>
        void Delete(IEnumerable<T> entities);
    }
}
