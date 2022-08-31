using System.Collections;
using System.Runtime.InteropServices;

namespace GenericApiControllers.Services;

public class StorageService<T> : IStorageService<T> where T : class
{
    readonly Dictionary<Guid, T> _storage = new Dictionary<Guid, T>();


    Task<IEnumerable<T>> IStorageService<T>.GetAll() => Task.FromResult<IEnumerable<T>>(_storage.Values);

    Task<T> IStorageService<T>.GetById(Guid id) => Task.FromResult(_storage.FirstOrDefault(t => t.Key == id).Value);

    Task IStorageService<T>.AddOrUpdate(Guid id, T item)
    {
        _storage[id] = item;
        return Task.CompletedTask;
    }
}