
using System;

namespace BalancePlatform.Backend.Infrastructure.Entites
{
    /// <summary>
    /// Приглашение пользователю на вступление в группу (группа -> пользователь)
    /// </summary>
    public class GroupToUserRequestDao : EntityWithIdDao<int>
    {
        /// <summary>
        /// ID группы, которая отправляет приглашение
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// Группа, которая отправляет приглашение
        /// </summary>
        public GroupDao Group { get; set; }

        /// <summary>
        /// ID пользователя, которого приглашают в группу
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Пользователь, которого приглашают в группу
        /// </summary>
        public UserDao User { get; set; }

        /// <summary>
        /// Дата отправки приглашения
        /// </summary>
        public DateTime DateCreate { get; set; }
    }
}
