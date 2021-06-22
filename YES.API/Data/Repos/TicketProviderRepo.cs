using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using YES.Api.Data.Database;
using YES.Api.Data.Entities;

namespace YES.Api.Data.Repos
{
    public class TicketProviderRepo : GenericRepo<TicketProvider>, ITicketProviderRepo
    {
        public TicketProviderRepo(YesDBContext context) : base(context)
        {
        }

        public override async Task<TicketProvider> GetEntityAsync(int id)
        {
            return await _context.TicketProviders
                                 .Include(x => x.Address)
                                 .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<TicketProvider>> GetAllTicketProvidersAsync()
        {
            return await _context.TicketProviders
                                     .Include(x => x.Address)
                                     .Include(x => x.Events)
                                     .ToListAsync();
        }

        public override async Task<bool> DeleteEntityAsync(int id)
        {
            TicketProvider provider = await _context.TicketProviders
                                     .Include(x => x.Address)
                                     .FirstOrDefaultAsync(x => x.Id == id);
            if (provider != null)
            {
                if (provider.Address != null)
                {
                    _context.Remove(provider.Address);
                }
                _context.Remove(provider);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public virtual async Task<TicketProvider> GetTicketProviderByEmailAsync(string email)
        {
            return await _context.TicketProviders.SingleOrDefaultAsync(x => x.Email == email);
        }

        public override async Task<bool> UpdateEntityAsync(TicketProvider entity)
        {
            _context.Update(entity);
            _context.Entry(entity).Property(p => p.PasswordHash).IsModified = false;
            _context.Entry(entity).Property(p => p.PasswordSalt).IsModified = false;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}