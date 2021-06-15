using AutoMapper;
using YES.Server.Data.Entities;
using YES.Server.Enums;
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
            CreateMap<TicketCategory, TicketCategoryDto>().ReverseMap();
            CreateMap<TicketCustomer, CustomerWithTicketsDto>();

            CreateMap<Event, EventDto>()
                .ForMember(d => d.Status, x => x.MapFrom(y => y.Status.ToString()));

            CreateMap<EventDto, Event>()
                .ForMember(d => d.Status, x => x.MapFrom(y => ConvertToStatusEnum(y.Status)));            

            CreateMap<Ticket, TicketDto>()
                .ForMember(d => d.CustomerFirstName, x => x.MapFrom(y => y.TicketCustomer.FirstName))
                .ForMember(d => d.CustomerLastName, x => x.MapFrom(y => y.TicketCustomer.LastName))
                .ForMember(d => d.EventName, x => x.MapFrom(y => y.Event.EventInfo.Name))
                .ForMember(d => d.VanueName, x => x.MapFrom(y => y.Event.Venue.Name))
                .ForMember(d => d.VenueAddress, x => x.MapFrom(y => y.Event.Venue.Address));                
        }

        public Status ConvertToStatusEnum(string value)
        {
            Status defaultValue = Status.Default;
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }

            return Status.TryParse<Status>(value, true, out Status result) ? result : defaultValue;
        }
    }
}