using AutoMapper;
using RAS.Core.Aggregates.Menu.Entities;
using RAS.Core.Aggregates.Menu.Models;
using RAS.Core.Aggregates.User.Entities;
using RAS.Core.Aggregates.Order.Entities;
using RAS.Core.Aggregates.User.Models;
using RAS.Core.Aggregates.Order.Models;

namespace RAS.API;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<UserEntity, UserModel>();
        CreateMap<OrderEntity, OrderModel>().ReverseMap();
        CreateMap<MenuItemEntity, MenuItemModel>().ReverseMap();
        CreateMap<MenuEntity, MenuModel>()
            .ForMember(dest => dest.MenuItems, opt => opt.MapFrom(x => x.MenuItems.Select(x => x.MenuItem)));
        CreateMap<MenuModel, MenuEntity>()
            .ForMember(dest => dest.MenuItems, opt => opt.MapFrom(src => src.MenuItems.Select(x => new MenuMenuItemEntity { MenuId = src.Id, MenuItemId = x.Id })));
    
}
}
