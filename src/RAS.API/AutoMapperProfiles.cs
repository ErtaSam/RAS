using AutoMapper;
using RAS.Core.Aggregates.User.Entities;
using RAS.Core.Aggregates.User.Models;

namespace RAS.API;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<UserEntity, UserModel>();
    }
}
