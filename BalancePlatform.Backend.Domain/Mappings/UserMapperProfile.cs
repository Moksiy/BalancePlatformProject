using BalancePlatform.Backend.Domain.Entities.Users;
using BalancePlatform.Backend.Infrastructure.Entites;

namespace BalancePlatform.Backend.Domain.Mappings
{
    public class UserMapperProfile : AutoMapper.Profile
    {
        public UserMapperProfile()
        {
            CreateMap<UserDao, User>()
                .ForMember(p => p.Id, a => a.MapFrom(p => p.Id))
                .ForMember(p => p.Login, a => a.MapFrom(p => p.Login))
                .ForMember(p => p.UserName, a => a.MapFrom(p => p.UserName))
                .ForMember(p => p.Email, a => a.MapFrom(p => p.Email))
                .ForMember(p => p.RoleId, a => a.MapFrom(p => p.RoleId))
                .ForMember(p => p.IsActive, a => a.MapFrom(p => p.IsActive))
                ;
        }
    }
}
