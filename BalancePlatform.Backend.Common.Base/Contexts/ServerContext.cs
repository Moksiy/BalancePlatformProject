using System;

namespace BalancePlatform.Backend.Common.Base.Contexts
{
    /// <summary>
    /// Контекст сервера
    /// </summary>
    public static class ServerContext
    {
        [ThreadStatic]
        private static int _userId;
        [ThreadStatic]
        private static int _userRoleId;
        [ThreadStatic]
        private static string _userName;

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public static int UserId
        {
            get => _userId;
            set
            {
                if (value.Equals(_userId)) return;
                _userId = value;
            }
        }

        /// <summary>
        /// Идентификатор роли пользователя
        /// </summary>
        public static int UserRoleId
        {
            get => _userRoleId;
            set
            {
                if (value.Equals(_userRoleId)) return;
                _userRoleId = value;
            }
        }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public static string UserName
        {
            get => _userName;
            set
            {
                if (value.Equals(_userName)) return;
                _userName = value;
            }
        }
    }
}
