using GenericApiControllers.Services;
using Microsoft.AspNetCore.Mvc;

namespace GenericApiControllers.Controllers;

public class BaseController<T> : Controller where T : class
{
    readonly IStorageService<T> _storage;
    
    public BaseController(IStorageService<T> storage)
    {
        _storage = storage;
    }

    [HttpGet]
    public Task<IEnumerable<T>> Get() => _storage.GetAll();

    [HttpGet("{id:guid}")]
    public Task<T> Get(Guid id) => _storage.GetById(id);

    [HttpPost]
    public void Post(Guid id, [FromBody] T value) => _storage.AddOrUpdate(id, value);
}