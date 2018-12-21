using DataAccess.Repo;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UoW
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Gets the connection string.
        /// </summary>
        string ConnectionString { get; }

        /// <summary>
        /// Repose this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IRepository<T> Repo<T>() where T : BaseEntity;

        /// <summary>
        /// Save this instance.
        /// </summary>
        void Save();

        /// <summary>
        /// Automatics the detect changes enabled.
        /// </summary>
        /// <param name="value"></param>
        void AutoDetectChangesEnabled(bool value);

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        void Dispose();

        //int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters);
    }
}
