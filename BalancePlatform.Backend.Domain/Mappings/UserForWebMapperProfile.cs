using BalancePlatform.Backend.Domain.Entities.Users;
using BalancePlatform.Backend.Infrastructure.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancePlatform.Backend.Domain.Mappings
{
    public class UserForWebMapperProfile : AutoMapper.Profile
    {
        public UserForWebMapperProfile()
        {
            /*CreateMap<UserDao, UserForWeb>()
                .ForMember(p => p.Id, a => a.MapFrom(p => p.Id))
                .ForMember(p => p.Name, a => a.MapFrom(p => p.UserName))
                ;*/
        }
    }
}
