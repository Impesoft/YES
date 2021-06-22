using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using YES.Api.Data.Database;
using YES.Api.Data.Entities;
using YES.Api.Data.Repos.Interfaces;

namespace YES.Api.Data.Repos
{
    public class TicketCustomerRepo : GenericRepo<TicketCustomer>, ITicketCustomerRepo
    {
        public TicketCustomerRepo(YesDBContext context) : base(context)
        {
        }

        public override async Task<TicketCustomer> GetEntityAsync(int id)
        {
            return await _context.TicketCustomers
                                 .Include(x => x.Address)
                                 .Include(x => x.Tickets)
                                 .ThenInclude(x => x.TicketCategory)
                                 .Include(x => x.Tickets)
                                 .ThenInclude(x => x.Event)
                                 .ThenInclude(x => x.EventInfo)
                                 .Include(x => x.Tickets)
                                 .ThenInclude(x => x.Event)
                                 .ThenInclude(x => x.Venue)
                                 .ThenInclude(x => x.Address)
                                 .FirstOrDefaultAsync(x => x.Id == id);
        }

        public override async Task<bool> DeleteEntityAsync(int id)
        {
            TicketCustomer customer = await _context.TicketCustomers
                                     .Include(x => x.Address)
                                     .FirstOrDefaultAsync(x => x.Id == id);
            if (customer != null)
            {
                if (customer.Address != null)
                {
                    _context.Remove(customer.Address);
                }
                _context.Remove(customer);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public virtual async Task<TicketCustomer> GetTicketCustomerByEmailAsync(string email)
        {
            return await _context.TicketCustomers.SingleOrDefaultAsync(x => x.Email == email);
        }

        public override async Task<bool> UpdateEntityAsync(TicketCustomer entity)
        {
            _context.Update(entity);
            _context.Entry(entity).Property(p => p.PasswordHash).IsModified = false;
            _context.Entry(entity).Property(p => p.PasswordSalt).IsModified = false;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}