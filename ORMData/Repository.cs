using System;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ORMData
{
    public abstract class Repository<T, PK, DB> : Repository<T, DB>, IRepository<T, PK>
        where T : class
        where DB : DbContext
    {
        public Repository(DB db) : base(db)
        {
        }

        public virtual T Read(PK id)
        {
            return Set.Find(id);
        }

        public virtual Task<T> ReadAsync(PK id)
        {
            return Set.FindAsync(id);
        }
    }

    public abstract class Repository<T, PK1, PK2, DB> : Repository<T, DB>, IRepository<T, PK1, PK2>
        where T : class
        where DB : DbContext
    {
        public Repository(DB db) : base(db)
        {
        }

        public abstract T Read(PK1 id1, PK2 id2);
        public abstract Task<T> ReadAsync(PK1 id1, PK2 id2);
    }

    public abstract class Repository<T, PK1, PK2, PK3, DB> : Repository<T, DB>, IRepository<T, PK1, PK2, PK3>
        where T : class
        where DB : DbContext
    {
        public Repository(DB db) : base(db)
        {
        }

        public abstract T Read(PK1 id1, PK2 id2, PK3 id3);
        public abstract Task<T> ReadAsync(PK1 id1, PK2 id2, PK3 id3);
    }

    public abstract class Repository<T, DB> : IRepository<T>
        where T : class
        where DB : DbContext
    {
        protected DB _db;

        public Repository(DB db)
        {
            _db = db;
        }

        protected abstract DbSet<T> Set { get; }

        public virtual T Create(T item)
        {
            return Set.Add(item);
        }

        public virtual IQueryable<T> ReadAll()
        {
            return Set;
        }

        public virtual IQueryable<T> ReadAllAsync()
        {
            return Set;
        }

        public virtual IQueryable<T> ReadPage(ReadPage page)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(T item)
        {
            if (!IsAttached(item))
            {
                _db.Entry(item).State = EntityState.Modified;
            }
        }
        public virtual void UpdateRecord(T item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public virtual void Delete(T item)
        {
            Set.Remove(item);
        }

        public virtual int Count()
        {
            return Set.Count();
        }

        //
        // Summary:
        //     Saves all changes made in this context to the underlying database.
        //
        // Returns:
        //     The number of objects written to the underlying database.
        //
        // Exceptions:
        //   System.Data.Entity.Infrastructure.DbUpdateException:
        //     An error occurred sending updates to the database.
        //
        //   System.Data.Entity.Infrastructure.DbUpdateConcurrencyException:
        //     A database command did not affect the expected number of rows. This usually
        //     indicates an optimistic concurrency violation; that is, a row has been changed
        //     in the database since it was queried.
        //
        //   System.Data.Entity.Validation.DbEntityValidationException:
        //     The save was aborted because validation of entity property values failed.
        //
        //   System.NotSupportedException:
        //     An attempt was made to use unsupported behavior such as executing multiple
        //     asynchronous commands concurrently on the same context instance.
        //
        //   System.ObjectDisposedException:
        //     The context or connection have been disposed.
        //
        //   System.InvalidOperationException:
        //     Some error occurred attempting to process entities in the context either
        //     before or after sending commands to the database.
        public virtual void Save()
        {
            _db.SaveChanges();
        }

        //
        // Summary:
        //     Asynchronously saves all changes made in this context to the underlying database.
        //
        // Returns:
        //     A task that represents the asynchronous save operation.  The task result
        //     contains the number of objects written to the underlying database.
        //
        // Exceptions:
        //   System.Data.Entity.Infrastructure.DbUpdateException:
        //     An error occurred sending updates to the database.
        //
        //   System.Data.Entity.Infrastructure.DbUpdateConcurrencyException:
        //     A database command did not affect the expected number of rows. This usually
        //     indicates an optimistic concurrency violation; that is, a row has been changed
        //     in the database since it was queried.
        //
        //   System.Data.Entity.Validation.DbEntityValidationException:
        //     The save was aborted because validation of entity property values failed.
        //
        //   System.NotSupportedException:
        //     An attempt was made to use unsupported behavior such as executing multiple
        //     asynchronous commands concurrently on the same context instance.
        //
        //   System.ObjectDisposedException:
        //     The context or connection have been disposed.
        //
        //   System.InvalidOperationException:
        //     Some error occurred attempting to process entities in the context either
        //     before or after sending commands to the database.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported.
        //     Use 'await' to ensure that any asynchronous operations have completed before
        //     calling another method on this context.
        public virtual Task<int> SaveAsync()
        {
            return _db.SaveChangesAsync();
        }

        //
        // Summary:
        //     Asynchronously saves all changes made in this context to the underlying database.
        //
        // Parameters:
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task
        //     to complete.
        //
        // Returns:
        //     A task that represents the asynchronous save operation.  The task result
        //     contains the number of objects written to the underlying database.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     Thrown if the context has been disposed.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported.
        //     Use 'await' to ensure that any asynchronous operations have completed before
        //     calling another method on this context.
        public virtual Task<int> SaveAsync(CancellationToken cancellationToken)
        {
            return _db.SaveChangesAsync(cancellationToken);
        }

        protected bool IsAttached(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            System.Data.Entity.Core.Objects.ObjectStateEntry entry;
            var objectStateManager = ((System.Data.Entity.Infrastructure.IObjectContextAdapter)_db).ObjectContext.ObjectStateManager;

            if (objectStateManager.TryGetObjectStateEntry(item, out entry))
            {
                return (entry.State != EntityState.Detached);
            }
            return false;
        }
    }
}