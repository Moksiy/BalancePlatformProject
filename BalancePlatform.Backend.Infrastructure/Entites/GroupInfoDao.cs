using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancePlatform.Backend.Infrastructure.Entites
{
    /// <summary>
    /// Информация о группе
    /// </summary>
    public class GroupInfoDao : EntityDao
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Ссылка на фото
        /// </summary>
        public string ImageUrl { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Место в рейтинге
        /// </summary>
        public int PlaceOnTop { get; set; }

        /// <summary>
        /// Количество побед
        /// </summary>
        public int Wins { get; set; }

        /// <summary>
        /// Количество ничьих
        /// </summary>
        public int Draws { get; set; }

        /// <summary>
        /// Количество поражений
        /// </summary>
        public int Defeats { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int UsersCount { get; set; }
    }
}
