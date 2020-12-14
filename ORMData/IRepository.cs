using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ORMData
{
    public interface IRepository<T>
    {
        T Create(T item);
        IQueryable<T> ReadAll();
        IQueryable<T> ReadPage(ReadPage page);
        void Update(T item);
        void Delete(T item);
        int Count();

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
        void Save();

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
        Task<int> SaveAsync();

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
        Task<int> SaveAsync(CancellationToken cancellationToken);
    }

    public interface IRepository<T, PK> : IRepository<T>
    {
        T Read(PK id);
        Task<T> ReadAsync(PK id);
    }

    public interface IRepository<T, PK1, PK2> : IRepository<T>
    {
        T Read(PK1 id1, PK2 id2);
        Task<T> ReadAsync(PK1 id1, PK2 id2);
    }

    public interface IRepository<T, PK1, PK2, PK3> : IRepository<T>
    {
        T Read(PK1 id1, PK2 id2, PK3 id3);
        Task<T> ReadAsync(PK1 id1, PK2 id2, PK3 id3);
    }
}