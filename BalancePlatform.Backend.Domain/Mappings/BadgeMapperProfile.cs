
using BalancePlatform.Backend.Domain.Entities.Branches;
using BalancePlatform.Backend.Infrastructure.Entites;

namespace BalancePlatform.Backend.Domain.Mappings
{
    public class BadgeMapperProfile : AutoMapper.Profile
    {
        public BadgeMapperProfile()
        {
            CreateMap<BadgeDao, Badge>()
                .ForMember(p => p.Id, a => a.MapFrom(p => p.Id))
                .ForMember(p => p.Title, a => a.MapFrom(p => p.Name))
                .ForMember(p => p.Description, a => a.MapFrom(p => p.Description))
                .ForMember(p => p.ImgUrl, a => a.MapFrom(p => p.ImageUrl))
                .ForMember(p => p.Score, a => a.MapFrom(p => p.Score))
                .ForMember(p => p.SpentCurrency, a => a.MapFrom(p => p.SpentCurrency))
                ;
        }
    }
}
