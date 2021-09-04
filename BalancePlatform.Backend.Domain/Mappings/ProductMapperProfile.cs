using BalancePlatform.Backend.Domain.Entities.ShopItems;
using BalancePlatform.Backend.Infrastructure.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancePlatform.Backend.Domain.Mappings
{
    public class ProductMapperProfile : AutoMapper.Profile
    {
        public ProductMapperProfile()
        {
            CreateMap<ProductDao, Product>()
                .ForMember(p => p.Id, a => a.MapFrom(p => p.Id))
                .ForMember(p => p.Title, a => a.MapFrom(p => p.Name))
                .ForMember(p => p.Description, a => a.MapFrom(p => p.Description))
                .ForMember(p => p.ImgUrl, a => a.MapFrom(p => p.ImageUrl))
                .ForMember(p => p.Price, a => a.MapFrom(p => p.Price))
                .ForMember(p => p.CanBy, a => a.MapFrom(p => true))
                ;
        }
    }
}
