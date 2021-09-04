using BalancePlatform.Backend.Domain.Entities.Groups;
using BalancePlatform.Backend.Infrastructure.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancePlatform.Backend.Domain.Mappings
{
    public class GroupMapperProfile : AutoMapper.Profile
    {
        public GroupMapperProfile()
        {
            CreateMap<GroupDao, Group>()
                .ForMember(p => p.Id, a => a.MapFrom(p => p.Id))
                .ForMember(p => p.Name, a => a.MapFrom(p => p.Name))
                .ForMember(p => p.Description, a => a.MapFrom(p => p.Description))
                ;
        }
    }
}