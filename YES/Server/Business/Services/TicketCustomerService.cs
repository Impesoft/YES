using AutoMapper;
using System.Threading.Tasks;
using YES.Server.Data.Entities;
using YES.Server.Data.Repos;
using YES.Shared.Dto;

namespace YES.Server.Business.Services
{
    public class TicketCustomerService : ITicketCustomerService
    {
        private readonly ITicketCustomerRepo _ticketCustomerRepo;
        private readonly IMapper _mapper;

        public TicketCustomerService(ITicketCustomerRepo ticketCustomerRepo, IMapper mapper)
        {
            _ticketCustomerRepo = ticketCustomerRepo;
            _mapper = mapper;
        }
        public async Task<CustomerWithTicketsDto> GetTicketCustomerByIdAsync(int id)
        {
            TicketCustomer customer = await _ticketCustomerRepo.GetEntityAsync(id);
            return _mapper.Map<CustomerWithTicketsDto>(customer);
        }

    }
}
