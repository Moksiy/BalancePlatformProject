using AutoMapper;
using BalancePlatform.Backend.Common.Base.Contexts;
using BalancePlatform.Backend.Common.Base.Helpers;
using BalancePlatform.Backend.Domain.Entities.Base;
using BalancePlatform.Backend.Domain.Entities.Profiles;
using BalancePlatform.Backend.Domain.Entities.Users;
using BalancePlatform.Backend.Domain.Ninject;
using BalancePlatform.Backend.Domain.Services.Implementations.BaseImplementations;
using BalancePlatform.Backend.Domain.Services.Interfaces.BalancePlatformInterfaces;
using BalancePlatform.Backend.Infrastructure.Contexts;
using BalancePlatform.Backend.Infrastructure.Entites;
using BalancePlatform.Backend.Infrastructure.Repositories.Interfaces.BaseInterfaces;
using Ninject;
using Ninject.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancePlatform.Backend.Domain.Services.Implementations.BalancePlatformImplementations
{
    /// <summary>
    /// Сервис работы с пользователями
    /// </summary>
    public class UserService : BaseService, IUserService
    {
        private readonly BalancePlatformContext _balancePlatformContext;

        private readonly IEntityWithIdRepository<UserDao, int> _userRepository;

        private readonly IEntityRepository<UserTokenDao> _userTokenRepository;

        private readonly IMapper _mapper;

        /// <summary>
        /// Сервис работы с пользователями
        /// </summary>
        public UserService()
        {
            IKernel kernel = new StandardKernel(new BalancePlatformModule());

            _balancePlatformContext = kernel.Get<BalancePlatformContext>();

            _userRepository = kernel.Get<IEntityWithIdRepository<UserDao, int>>(new ConstructorArgument("context", _balancePlatformContext));
            _userTokenRepository = kernel.Get<IEntityRepository<UserTokenDao>>(new ConstructorArgument("context", _balancePlatformContext));

            _mapper = kernel.Get<IMapper>();
        }

        /// <summary>
        /// Возвращает интерфейс для запроса пользователей
        /// </summary>
        /// <returns>Интерфейс для запроса пользователей</returns>
        public IQueryable<User> GetQueryable()
        {
            var userQueryable = _userRepository.GetQueryable();
            return _mapper.ProjectTo<User>(userQueryable);
        }

        /// <summary>
        /// Создаёт пользователя
        /// </summary>
        /// <param name="user">Данные пользователя</param>
        public void Create(NewUser user)
        {
            var userDao = new UserDao
            {
                Login = user.Login,
                UserName = user.UserName,
                Email = user.Email,
                PasswordHash = string.Empty,
                Salt = string.Empty,
                RoleId = user.RoleId,
                IsActive = true
            };
            _userRepository.Create(userDao);

            _balancePlatformContext.SaveChanges();
        }

        /// <summary>
        /// Ищет пользователя по его токену
        /// </summary>
        /// <param name="token">Токен</param>
        /// <returns>Пользователь</returns>
        public User GetUserByToken(string token)
        {
            var userId = _userTokenRepository.GetQueryable()
                .FirstOrDefault(x => x.Token == token)?.UserId;
            if (userId != null)
            {
                var userDao = _userRepository.GetById(userId.Value);
                if (userDao != null && userDao.IsActive)
                {
                    return _mapper.Map<UserDao, User>(userDao);
                }
            }
            return null;
        }

        /// <summary>
        /// Возвращает профиль авторизованного пользователя
        /// </summary>
        /// <returns>Профиль авторизованного пользователя</returns>
        public BaseResult GetProfileResult()
        {
            var userDao = _userRepository.GetById(ServerContext.UserId);

            if (userDao != null)
            {
                return new ProfileResult
                {
                    ErrorCode = 0,
                    ErrorText = string.Empty,
                    Data = new ProfileData
                    {
                    }
                };
            }
            return new BaseResult
            {
                ErrorCode = 500,
                ErrorText = "Пользователь не найден"
            };
        }

        /// <summary>
        /// Создаёт захешированную пару пароль-соль по предоставленному паролю
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private (string salt, string passwordHash) CreatePassword(string password)
        {
            var salt = "bDz<!%#u8&";//Md5Helper.CalculateMd5Hash(Guid.NewGuid().ToString()).Substring(0, 8);    -- todo Временно
            var passwordHash = Md5Helper.CalculateMd5Hash(password + salt);//Md5Helper.CalculateMd5Hash(salt + "/" + password + "\\" + salt);
            return (salt, passwordHash);
        }
    }
}
