﻿namespace SocialNetworkBE.Domain.Interfaces.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task<T> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task RemoveAsync(T entity);
    IQueryable<T> GetQueryable();
}