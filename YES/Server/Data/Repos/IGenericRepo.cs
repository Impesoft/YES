﻿using System.Collections.Generic;
using System.Threading.Tasks;
using YES.Server.Data.Entities;

namespace YES.Server.Data.Repos
{
    public interface IGenericRepo<T> where T : EntityBase
    {
        Task<bool> AddEntitiesAsync(IEnumerable<T> entities);
        Task<bool> AddEntityAsync(T entity);
        Task<bool> DeleteEntityAsync(int id);
        Task<IEnumerable<T>> GetAllEntitiesAsync();
        Task<T> GetEntityAsync(int id);
        Task<bool> UpdateEntitiesAsync(IEnumerable<T> entities);
        Task<bool> UpdateEntityAsync(T entity);
    }
}