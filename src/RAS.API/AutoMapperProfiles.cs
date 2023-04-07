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
        CreateMap<MenuEntity, MenuModel>().ReverseMap();
    }
}
