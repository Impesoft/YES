using AutoMapper;
using System;
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

            CreateMap<Event, EventDto>()
                .ForMember(d => d.Status, x => x.MapFrom(y => y.Status.ToString()));

            CreateMap<EventDto, Event>()
                .ForMember(d =>  d.Status, x => x.MapFrom(y => ConvertToStatusEnum(y.Status)));
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
