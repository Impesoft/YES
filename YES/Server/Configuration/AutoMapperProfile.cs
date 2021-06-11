using AutoMapper;
using YES.Server.Data.Entities;
using YES.Shared.Dto;

namespace YES.Server.Configuration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Venue, VenueDto>().ReverseMap();
            CreateMap<TicketProvider, TicketProviderDto>().ReverseMap();
            CreateMap<EventInfo, EventInfoDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();

            CreateMap<Event, EventDto>()
                .ForMember(d => d.Status, x => x.MapFrom(y => y.Status.ToString()))
                .ReverseMap();
                        
        }
    }
}
