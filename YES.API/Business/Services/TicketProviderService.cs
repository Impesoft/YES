using AutoMapper;
using System.Threading.Tasks;
using YES.Api.Data.Entities;
using YES.Api.Data.Repos;
using YES.Shared.Dto;

namespace YES.Api.Business.Services
{
    public class TicketProviderService : ITicketProviderService
    {
        private readonly ITicketProviderRepo _ticketProviderRepo;
        private readonly IMapper _mapper;

        public TicketProviderService(ITicketProviderRepo ticketProviderRepo, IMapper mapper)
        {
            _ticketProviderRepo = ticketProviderRepo;
            _mapper = mapper;
        }

        public async Task<TicketProviderDto> GetTicketProviderByIdAsync(int id)
        {
            TicketProvider provider = await _ticketProviderRepo.GetEntityAsync(id);
            return _mapper.Map<TicketProviderDto>(provider);
        }     

        public async Task<bool> UpdateTicketProvider(TicketProviderDto ticketProviderDto)
        {
            TicketProvider provider = _mapper.Map<TicketProvider>(ticketProviderDto);
            return await _ticketProviderRepo.UpdateEntityAsync(provider);
        }

        public async Task<bool> DeleteTicketProvider(int id)
        {
            return await _ticketProviderRepo.DeleteEntityAsync(id);
        }
    }
}
