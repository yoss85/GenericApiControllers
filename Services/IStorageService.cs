using System.Collections;

namespace GenericApiControllers.Services;

public interface IStorageService<T> where T: class
{
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(Guid id);
    Task AddOrUpdate(Guid id, T item);
}