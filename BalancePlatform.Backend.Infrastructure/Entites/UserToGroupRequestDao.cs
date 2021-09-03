
using System;

namespace BalancePlatform.Backend.Infrastructure.Entites
{
    /// <summary>
    /// Запрос пользователя на вступление в группу (пользователь -> группа)
    /// </summary>
    public class UserToGroupRequestDao : EntityWithIdDao<int>
    {
        /// <summary>
        /// ID пользователя, который хочет вступить в группу
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Пользователь, который хочет вступить в группу
        /// </summary>
        public UserDao User { get; set; }

        /// <summary>
        /// ID группы, куда пользователь отправил запрос на вступление
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// Группа, куда пользователь отправил запрос на вступление
        /// </summary>
        public GroupDao Group { get; set; }

        /// <summary>
        /// Дата создания запроса
        /// </summary>
        public DateTime DateCreate { get; set; }
    }
}
