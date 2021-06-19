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

        public async Task<IEnumerable<TicketProvider>> GetAllTicketProvidersAsync()
        {
            return await _context.TicketProviders
                                     .Include(x => x.Address)
                                     .Include(x => x.Events)
                                     .ToListAsync();
        }
        public virtual async Task<TicketProvider> GetTicketProviderByEmailAsync(string email)
        {
            return await _context.TicketProviders.SingleOrDefaultAsync(x => x.Email == email);
        }
    }
}