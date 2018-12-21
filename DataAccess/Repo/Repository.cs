using Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repo
{
    public class Repository<T>: IRepository<T> where T: BaseEntity
    {
        private readonly Context _context;
        private DbSet<T> _entities;

        public Repository(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Entities
        /// </summary>
        protected virtual DbSet<T> Entities => _entities ?? (_entities = _context.Set<T>());

        /// <summary>
        /// Get a table
        /// </summary>
        public virtual IQueryable<T> Table => Entities;

        /// <summary>
        /// Get entity by identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T GetById(object id)
        {
            return Entities.Find(id);
        }

        /// <summary>
        /// Insert a entity.
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Insert(T entity)
        {
            if(entity == null)
            {
                throw new ArgumentException("entity");
            }

            Entities.Add(entity);
        }

        /// <summary>
        /// Insert entities.
        /// </summary>
        /// <param name="entities"></param>
        public virtual void Insert(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentException("entities");
            }

            Entities.AddRange(entities);
        }

        /// <summary>
        /// Attach a entity.
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Attach(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("entity");
            }

            Entities.AddOrUpdate(entity);
        }

        /// <summary>
        /// Attach entities.
        /// </summary>
        /// <param name="entities"></param>
        public virtual void Attach(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentException("entities");
            }

            foreach(var entity in entities)
            {
                Entities.Add(entity);

            }
        }

        /// <summary>
        /// Remove a entity.
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("entity");
            }

            Entities.Remove(entity);
        }

        /// <summary>
        /// Remove entities.
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentException("entity");
            }

            Entities.RemoveRange(entities);
        }
    }
}
