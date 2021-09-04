using BalancePlatform.Backend.Common.Base.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancePlatform.Backend.Domain.Entities.Battles
{
    /// <summary>
    /// Счет соревнования
    /// </summary>
    public class BattleScore : IEntity
    {
        public int BattleId { get; set; }

        public int Score { get; set; }
    }
}
