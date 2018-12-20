using Microsoft.AspNetCore.Server.Kestrel.Internal.System;
using System.Linq;
using System.Threading.Tasks;

public interface IGenericRepository<T> where T : class
{
    IQueryable<T> GetAll();

    Task<T> GetById(int id);

    Task<int> Create(T entity);

    Task Update(int id, T entity);

    Task Delete(int id);
}