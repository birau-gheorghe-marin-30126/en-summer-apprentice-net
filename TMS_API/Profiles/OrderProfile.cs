using TMS_API.Models.DTO;
using TMS_API.Models;
using AutoMapper;


namespace TMS_API.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            //CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>()
                .ForMember(dest => dest.TicketCategory, opt => opt.MapFrom(src => src.TicketCategory.Description))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User.UserName))
                .ReverseMap();
        }
    }
}
