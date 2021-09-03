using BalancePlatform.Backend.Common.Base.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancePlatform.Backend.Domain.Entities.Users
{
    /// <summary>
    /// Профиль пользователя
    /// </summary>
    public class UserProfile : IEntityWithId<int>
    {
        public int Id { get; set; }
        public string ImgUrl { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int PlaceOnTop { get; set; }
        public DateTime Birthday { get; set; }
        public string City { get; set; }
        public int Currency { get; set; }
        public int SpentCurrency { get; set; }
    }
}
