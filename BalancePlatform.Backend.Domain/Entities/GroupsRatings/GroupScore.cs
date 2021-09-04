using BalancePlatform.Backend.Common.Base.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancePlatform.Backend.Domain.Entities.GroupsRatings
{
    /// <summary>
    /// Счет группы
    /// </summary>
    public class GroupScore : IEntity
    {
        public int GroupId { get; set; }

        public int Score { get; set; }
    }
}
