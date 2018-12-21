using DataAccess.Repo;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UoW
{
    public class UnitOfWork: IUnitOfWork, IDisposable
    {
        private readonly Context _context = new Context();
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();
        private bool _disposed;

        public string ConnectionString => _context.Database.Connection.ConnectionString;

        public IRepository<T> Repo<T>() where T: BaseEntity
        {
            if (_repositories.Keys.Contains(typeof(T)))
            {
                return _repositories[typeof(T)] as IRepository<T>;
            }

            IRepository<T> repo = new Repository<T>(_context);
            _repositories.Add(typeof(T), repo);
            return repo;
        }

        //public int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters)
        //{
        //    return _context.ExecuteSqlCommand(sql, doNotEnsureTransaction, timeout);
        //}

        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch(DbEntityValidationException dbEx)
            {
                SaveFullError(dbEx);
            }
        }

        public void AutoDetectChangesEnabled( bool value)
        {
            _context.Configuration.AutoDetectChangesEnabled = value;
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void SaveFullError(DbEntityValidationException exc)
        {
            var msg = string.Empty;
            foreach( var validationErrors in exc.EntityValidationErrors)
            {
                foreach( var error in validationErrors.ValidationErrors)
                {
                    msg += $"Property: {error.PropertyName} Error: {error.ErrorMessage}" + Environment.NewLine;
                }
            }
            //log;
        }
    }
}
