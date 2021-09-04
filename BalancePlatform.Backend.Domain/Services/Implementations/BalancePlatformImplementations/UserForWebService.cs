using AutoMapper;
using BalancePlatform.Backend.Domain.Entities.Branches;
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

namespace BalancePlatform.Backend.Domain.Services.Implementations.BalancePlatformImplementations
{
    /// <summary>
    /// Сервис работы с пользователями для веб интерфейса
    /// </summary>
    public class UserForWebService : BaseService, IUserForWebService
    {
        private readonly BalancePlatformContext _balancePlatformContext;

        private readonly IEntityWithIdRepository<UserDao, int> _userRepository;

        private readonly IEntityRepository<UserScoreDao> _scoreRepository;

        private readonly IEntityRepository<CurrencyDao> _currencyRepository;

        private readonly IEntityRepository<SpentCurrencyDao> _spentCurrencyRepository;

        private readonly IEntityRepository<BadgeDao> _badgeRepository;

        private readonly IEntityRepository<UserBadgeDao> _userBadgeRepository;

        private readonly IMapper _mapper;

        /// <summary>
        /// Сервис работы с пользователями для веб интерфейса
        /// </summary>
        public UserForWebService()
        {
            IKernel kernel = new StandardKernel(new BalancePlatformModule());

            _balancePlatformContext = kernel.Get<BalancePlatformContext>();

            _userRepository = kernel.Get<IEntityWithIdRepository<UserDao, int>>(new ConstructorArgument("context", _balancePlatformContext));

            _scoreRepository = kernel.Get<IEntityRepository<UserScoreDao>>(new ConstructorArgument("context", _balancePlatformContext));

            _currencyRepository = kernel.Get<IEntityRepository<CurrencyDao>>(new ConstructorArgument("context", _balancePlatformContext));

            _spentCurrencyRepository = kernel.Get<IEntityRepository<SpentCurrencyDao>>(new ConstructorArgument("context", _balancePlatformContext));

            _badgeRepository = kernel.Get<IEntityRepository<BadgeDao>>(new ConstructorArgument("context", _balancePlatformContext));

            _userBadgeRepository = kernel.Get<IEntityRepository<UserBadgeDao>>(new ConstructorArgument("context", _balancePlatformContext));

            _mapper = kernel.Get<IMapper>();
        }

        /// <summary>
        /// Возвращает интерфейс для запроса пользователей для веб интерфейса
        /// </summary>
        /// <returns>Интерфейс для запроса пользователей для веб интерфейса</returns>
        public IQueryable<UserForWeb> GetQueryable()
        {
            var userQueryable = _userRepository.GetQueryable().Where(x => x.IsActive).Where(x => x.RoleId == 3);
            return _mapper.ProjectTo<UserForWeb>(userQueryable);
        }

        /// <summary>
        /// Получить список пользователей с из позицией в топе
        /// </summary>
        /// <returns></returns>
        public List<UserInfo> GetUserList()
        {
            var userQueryable = _userRepository.GetQueryable()
                .ToList();

            var scoreQueryable = _scoreRepository.GetQueryable()
                .OrderByDescending(x => x.Score)
                .ToList();

            var result = from score in scoreQueryable
                         join user in userQueryable on score.UserId equals user.Id
                         select new UserInfo()
                         {
                             Id = user.Id,
                             Email = user.Email,
                             ImgUrl = user.ImageUrl,
                             Phone = user.PhoneNum,
                             Title = user.UserName,
                             PlaceOnTop = scoreQueryable.FindIndex(x => x.UserId == user.Id) + 1
                         };

            return result.ToList(); 
        }

        /// <summary>
        /// Получить профиль пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserProfile GetUserProfile(int id)
        {
            var user = _userRepository.GetById(id);

            var scoreQueryable = _scoreRepository.GetQueryable()
                .OrderByDescending(x => x.Score)
                .ToList();

            var currency = _currencyRepository.GetQueryable()
                .ToList();

            var spentCurrency = _spentCurrencyRepository.GetQueryable()
                .ToList();

            return new UserProfile()
            {
                 Id = user.Id,
                 City = user.City,
                 Birthday = user.BirthDate,
                 Email = user.Email,
                 ImgUrl = user.ImageUrl,
                 Phone = user.PhoneNum,
                 Title = user.UserName,
                 PlaceOnTop = scoreQueryable.FindIndex(x => x.UserId == user.Id) + 1,
                 Currency = currency.FirstOrDefault(x => x.UserId == user.Id).Value,
                 SpentCurrency = spentCurrency.FirstOrDefault(x => x.UserId == user.Id).Value
            };
        }

        /// <summary>
        /// Получить рейтинг пользователей
        /// </summary>
        /// <returns></returns>
        public List<UserRating> GetUserRatings()
        {
            var users = _userRepository.GetQueryable()
                .ToList();

            var userScores = _scoreRepository.GetQueryable()
                .OrderByDescending(x => x.Score)
                .ToList();

            return users.Select(x => new UserRating()
            {
                Id = x.Id,
                ImgUrl = x.ImageUrl,
                Title = x.UserName,
                Type = "user",
                PlaceOnTop = userScores.FindIndex(p => p.UserId == x.Id) + 1,
                Score = userScores.FirstOrDefault(p => p.UserId == x.Id).Score,
                TotalScore = 50 
            }).OrderBy(x => x.PlaceOnTop)
            .ToList();
        }

        /// <summary>
        /// Получить бейджи пользователя
        /// </summary>
        /// <returns></returns>
        public List<Badge> GetUserBadges(int id)
        {
            var userBadges = _userBadgeRepository.GetQueryable()
                .Where(x => x.UserId == id)
                .Select(x => x.BadgeId)
                .ToList();

            return _badgeRepository.GetQueryable()
                .Where(x => userBadges.Contains(x.Id))
                .Select(p => new Badge() 
                {
                    Id = p.Id,
                    Description = p.Description,
                    Score = p.Score,
                    ImgUrl = p.ImageUrl,
                    Title = p.Name,
                    SpentCurrency = p.SpentCurrency
                }).ToList();
        }
    }
}
