using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using YES.Server.Data.Database;
using YES.Server.Data.Entities;

namespace YES.Server.Data.Repos
{
    public class GenericRepo<T> : IGenericRepo<T> where T : EntityBase
    {
        public YesDBContext _context;

        public GenericRepo(YesDBContext context)
        {
            _context = context;
        }

        public virtual async Task<bool> AddEntityAsync(T entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public virtual async Task<bool> AddEntitiesAsync(IEnumerable<T> entities)
        {
            await _context.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
            return true;
        }

        public virtual async Task<bool> UpdateEntitiesAsync(IEnumerable<T> entities)
        {
            _context.UpdateRange(entities);
            await _context.SaveChangesAsync();

            return true;
        }

        public virtual async Task<bool> UpdateEntityAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public virtual async Task<bool> DeleteEntityAsync(int id)
        {
            var test = await _context.FindAsync<T>(id);
            _context.Remove(test);
            await _context.SaveChangesAsync();
            return true;
        }
        public virtual async Task<IEnumerable<T>> GetAllEntitiesAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetEntityAsync(int id)
        {
            return await _context.FindAsync<T>(id);
        }
    }
}