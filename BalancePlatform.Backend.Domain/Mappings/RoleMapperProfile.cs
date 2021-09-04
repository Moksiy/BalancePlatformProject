using BalancePlatform.Backend.Domain.Entities.Roles;
using BalancePlatform.Backend.Infrastructure.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancePlatform.Backend.Domain.Mappings
{
    public class RoleMapperProfile : AutoMapper.Profile
    {
        public RoleMapperProfile()
        {
            CreateMap<RoleDao, Role>()
                .ForMember(p => p.Id, a => a.MapFrom(p => p.Id))
                .ForMember(p => p.Name, a => a.MapFrom(p => p.Name))
                .ForMember(p => p.IsActive, a => a.MapFrom(p => p.IsActive))
                ;
        }
    }
}
