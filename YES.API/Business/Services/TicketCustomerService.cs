using AutoMapper;
using System.Threading.Tasks;
using YES.Api.Data.Entities;
using YES.Api.Data.Repos.Interfaces;
using YES.Shared.Dto;

namespace YES.Api.Business.Services
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

        public async Task<CustomerWithTicketsDto> GetTicketCustomerWithTicketsByIdAsync(int id)
        {
            TicketCustomer customer = await _ticketCustomerRepo.GetEntityAsync(id);
            return _mapper.Map<CustomerWithTicketsDto>(customer);
        }
        public async Task<TicketCustomerDto> GetTicketCustomerByIdAsync(int id)
        {
            TicketCustomer customer = await _ticketCustomerRepo.GetEntityAsync(id);
            return _mapper.Map<TicketCustomerDto>(customer);
        }
        public async Task<bool> AddTicketCustomer(TicketCustomerDto ticketCustomerDto)
        {
            TicketCustomer customer = _mapper.Map<TicketCustomer>(ticketCustomerDto);
            return await _ticketCustomerRepo.AddEntityAsync(customer);
        }
        public async Task<bool> UpdateTicketCustomer(TicketCustomerDto ticketCustomerDto)
        {
            TicketCustomer customer = _mapper.Map<TicketCustomer>(ticketCustomerDto);
            return await _ticketCustomerRepo.UpdateEntityAsync(customer);
        }
        public async Task<bool> DeleteTicketCustomer(int id)
        {
            return await _ticketCustomerRepo.DeleteEntityAsync(id);
        }
    }
}

