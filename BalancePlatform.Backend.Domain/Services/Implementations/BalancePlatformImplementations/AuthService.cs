using AutoMapper;
using BalancePlatform.Backend.Common.Base.Helpers;
using BalancePlatform.Backend.Domain.Entities.Auth;
using BalancePlatform.Backend.Domain.Entities.Base;
using BalancePlatform.Backend.Domain.Entities.Roles;
using BalancePlatform.Backend.Domain.Ninject;
using BalancePlatform.Backend.Domain.Services.Implementations.BaseImplementations;
using BalancePlatform.Backend.Domain.Services.Interfaces.BalancePlatformInterfaces;
using BalancePlatform.Backend.Infrastructure.Contexts;
using BalancePlatform.Backend.Infrastructure.Entites;
using BalancePlatform.Backend.Infrastructure.Repositories.Interfaces.BaseInterfaces;
using Microsoft.EntityFrameworkCore;
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
    /// Сервис аутентификации
    /// </summary>
    public class AuthService : BaseService, IAuthService
    {
        private readonly BalancePlatformContext _balancePlatformContext;

        private readonly IEntityWithIdRepository<UserDao, int> _userRepository;

        private readonly IEntityRepository<UserTokenDao> _userTokenRepository;

        private readonly IMapper _mapper;

        /// <summary>
        /// Сервис аутентификации
        /// </summary>
        public AuthService()
        {
            IKernel kernel = new StandardKernel(new BalancePlatformModule());

            _balancePlatformContext = kernel.Get<BalancePlatformContext>();

            _userRepository = kernel.Get<IEntityWithIdRepository<UserDao, int>>(new ConstructorArgument("context", _balancePlatformContext));

            _userTokenRepository = kernel.Get<IEntityRepository<UserTokenDao>>(new ConstructorArgument("context", _balancePlatformContext));

            _mapper = kernel.Get<IMapper>();
        }

        /// <summary>
        /// Производит аутентификацию пользователя для мобильного приложения
        /// </summary>
        /// <param name="model">Данные аутентификации</param>
        /// <returns>Результат аутентификации</returns>
        public BaseResult Auth(AuthModel model)
        {
            var userDao = _userRepository.GetQueryable()
                .FirstOrDefault(x => x.Login.ToLower().Equals(model.Login.ToLower()));

            if (userDao != null)
            {
                if (string.IsNullOrWhiteSpace(model.Password))
                {
                    if (!string.IsNullOrWhiteSpace(userDao.PasswordHash)
                        && !string.IsNullOrWhiteSpace(userDao.Salt))
                    {
                        return new BaseResult
                        {
                            ErrorCode = 200,
                            ErrorText = "Пользователь существует и у него уже есть пароль"
                        };
                    }

                    return new BaseResult
                    {
                        ErrorCode = 201,
                        ErrorText = "Пользователь существует, но его пароль еще не установлен"
                    };
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(userDao.PasswordHash)
                        && !string.IsNullOrWhiteSpace(userDao.Salt))
                    {
                        var saltAndPassword = CreatePassword(model.Password);

                        if (saltAndPassword.passwordHash.Equals(userDao.PasswordHash))
                        {
                            var userTokenDao = _userTokenRepository.GetQueryable()
                                .Where(x => x.UserId == userDao.Id)
                                .Where(x => x.ExpirationDate >= DateTime.Today)
                                .OrderBy(x => x.ExpirationDate)
                                .FirstOrDefault();

                            if (userTokenDao == null)
                            {
                                userTokenDao = new UserTokenDao
                                {
                                    UserId = userDao.Id,
                                    ExpirationDate = DateTime.Today.AddMonths(1),
                                    Token = Md5Helper.CalculateMd5Hash($"{userDao.Id}|{Guid.NewGuid()}")
                                };
                                userTokenDao = _userTokenRepository.Create(userTokenDao);
                                _balancePlatformContext.SaveChanges();
                            }

                            return new AuthResult
                            {
                                ErrorCode = 0,
                                ErrorText = "Пользователь существует, у него есть пароль и он совпадает с указанным",
                                Data = new TokenData
                                {
                                    Token = userTokenDao.Token
                                }
                            };
                        }
                        else
                        {
                            return new BaseResult
                            {
                                ErrorCode = 401,
                                ErrorText = "Пользователь существует, у него есть пароль, но он не совпадает с указанным"
                            };
                        }
                    }
                    else
                    {
                        var saltAndPassword = CreatePassword(model.Password);
                        userDao.PasswordHash = saltAndPassword.passwordHash;
                        userDao.Salt = saltAndPassword.salt;
                        _userRepository.Update(userDao);

                        var userTokenDao = _userTokenRepository.GetQueryable()
                            .Where(x => x.UserId == userDao.Id)
                            .Where(x => x.ExpirationDate >= DateTime.Today)
                            .OrderBy(x => x.ExpirationDate)
                            .FirstOrDefault();

                        if (userTokenDao == null)
                        {
                            userTokenDao = new UserTokenDao
                            {
                                UserId = userDao.Id,
                                ExpirationDate = DateTime.Today.AddMonths(1),
                                Token = Md5Helper.CalculateMd5Hash($"{userDao.Id}|{Guid.NewGuid()}")
                            };
                            userTokenDao = _userTokenRepository.Create(userTokenDao);
                        }
                        _balancePlatformContext.SaveChanges();

                        return new AuthResult
                        {
                            ErrorCode = 0,
                            ErrorText = "Пользователь существует, но у него еще не было пароля",
                            Data = new TokenData
                            {
                                Token = userTokenDao.Token
                            }
                        };
                    }
                }
            }
            else
            {
                return new BaseResult
                {
                    ErrorCode = 404,
                    ErrorText = "Пользователь не найден"
                };
            }
        }

        /// <summary>
        /// Производит аутентификацию пользователя для веб интерфейса
        /// </summary>
        /// <param name="model">Данные аутентификации</param>
        /// <returns>Результат аутентификации</returns>
        public AuthResultModel AuthByСredentials(AuthModel model)
        {
            var userDao = _userRepository.GetQueryable().FirstOrDefault(x => x.Login.ToLower().Equals(model.Login.ToLower()));
            if (userDao != null)
            {
                if (!string.IsNullOrWhiteSpace(model.Password))
                {
                    if (!string.IsNullOrWhiteSpace(userDao.PasswordHash) && !string.IsNullOrWhiteSpace(userDao.Salt))
                    {
                        var saltAndPassword = CreatePassword(model.Password);

                        if (saltAndPassword.passwordHash.Equals(userDao.PasswordHash))
                        {
                            var userTokenDao = _userTokenRepository.GetQueryable()
                                .Where(x => x.UserId == userDao.Id)
                                .Where(x => x.ExpirationDate >= DateTime.Today)
                                .OrderBy(x => x.ExpirationDate)
                                .FirstOrDefault();

                            if (userTokenDao == null)
                            {
                                userTokenDao = new UserTokenDao
                                {
                                    UserId = userDao.Id,
                                    ExpirationDate = DateTime.Today.AddMonths(1),
                                    Token = Md5Helper.CalculateMd5Hash($"{userDao.Id}|{Guid.NewGuid()}")
                                };
                                userTokenDao = _userTokenRepository.Create(userTokenDao);
                                _balancePlatformContext.SaveChanges();
                            }

                            return new AuthResultModel()
                            {
                                User = new Entities.Users.UserForWeb()
                                {
                                    Id = userDao.Id,
                                    Name = userDao.UserName,
                                    ImageUrl = userDao.ImageUrl
                                },
                                Token = userTokenDao.Token,
                                ErrorCode = 0,
                                ErrorText = "Пользователь существует, у него есть пароль и он совпадает с указанным",
                            };
                        }
                        else
                        {
                            return new AuthResultModel()
                            {
                                ErrorCode = 401,
                                ErrorText = "Пользователь существует, у него есть пароль, но он не совпадает с указанным"
                            };
                        }
                    }
                    else
                    {
                        return new AuthResultModel()
                        {
                            ErrorCode = 201,
                            ErrorText = "Пользователь существует, но его пароль еще не установлен"
                        };
                    }
                }
                else
                {
                    return new AuthResultModel()
                    {
                        ErrorCode = 201,
                        ErrorText = "Пользователь существует, но пароль для аутентификации не получен"
                    };
                }
            }
            else
            {
                return new AuthResultModel()
                {
                    ErrorCode = 404,
                    ErrorText = "Пользователь не найден"
                };
            }
        }

        /// <summary>
        /// Производит аутентификацию пользователя по токену
        /// </summary>
        /// <param name="token">Токен</param>
        /// <returns>Результат аутентификации</returns>
        public AuthResultModel AuthByToken(TokenData token)
        {
            var tokenDao = _userTokenRepository.GetQueryable().FirstOrDefault(x => x.Token == token.Token);
            if (tokenDao != null)
            {
                if (tokenDao.ExpirationDate >= DateTime.Now)
                {
                    var userDao = _userRepository.GetQueryable().Include(x => x.Role).FirstOrDefault(x => x.Id == tokenDao.UserId);
                    if (userDao != null)
                    {
                        return new AuthResultModel()
                        {
                            User = new Entities.Users.UserForWeb()
                            {
                                Id = userDao.Id,
                                Name = userDao.UserName,
                                ImageUrl = userDao.ImageUrl
                            },
                            Token = tokenDao.Token,
                            ErrorCode = 0,
                            ErrorText = string.Empty
                        };
                    }
                    else
                    {
                        return new AuthResultModel()
                        {
                            ErrorCode = 404,
                            ErrorText = "Пользователь не найден"
                        };
                    }
                }
                else
                {
                    return new AuthResultModel()
                    {
                        ErrorCode = 403,
                        ErrorText = "Токен найден, но срок его действия вышел, требуется повторная аутентификация"
                    };
                }
            }
            else
            {
                return new AuthResultModel()
                {
                    ErrorCode = 404,
                    ErrorText = "Токен не найден"
                };
            }
        }

        #region Private

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

        #endregion
    }
}
