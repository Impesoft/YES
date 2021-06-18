using System.Collections.Generic;
using System.Threading.Tasks;
using YES.Api.Data.Entities;
using YES.Api.Data.Repos;
using YES.Api.Data.Repos.Interfaces;

namespace YES.Api.Business.Services
{
    public class UserService : IUserService
    {
        private readonly ITicketCustomerRepo _ticketCustomerRepo;
        private readonly ITicketProviderRepo _ticketProviderRepo;

        public UserService(ITicketCustomerRepo ticketCustomerRepo, ITicketProviderRepo ticketProviderRepo)
        {
            _ticketCustomerRepo = ticketCustomerRepo;
            _ticketProviderRepo = ticketProviderRepo;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            List<User> users = new();

            users.AddRange(await _ticketCustomerRepo.GetAllEntitiesAsync());
            users.AddRange(await _ticketProviderRepo.GetAllEntitiesAsync());

            return users;
        }
        public async Task<bool> UserExistsAsync(string eMail)
        {            
            var users = (List<User>)await GetAllUsersAsync();
            return users.Exists(x => x.Email.ToLower() == eMail.ToLower());
        }


        public virtual async Task<User> GetUserByEmailAsync(string email)
        {
            TicketCustomer ticketCustomer = await _ticketCustomerRepo.GetTicketCustomerByEmailAsync(email);
            TicketProvider ticketProvider = await _ticketProviderRepo.GetTicketProviderByEmailAsync(email);

            if (ticketCustomer != null)
            {
                return ticketCustomer;
            }
            else if (ticketProvider != null)
            {
                return ticketProvider;
            }
            else
            {
                return null;
            }
        }


    }
}
