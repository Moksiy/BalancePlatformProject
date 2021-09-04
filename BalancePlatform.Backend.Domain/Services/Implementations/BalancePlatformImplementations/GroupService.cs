using AutoMapper;
using BalancePlatform.Backend.Domain.Entities.Battles;
using BalancePlatform.Backend.Domain.Entities.Groups;
using BalancePlatform.Backend.Domain.Entities.GroupsRatings;
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
    /// Сервис работы с группами
    /// </summary>
    public class GroupService : BaseService, IGroupService
    {
        private readonly BalancePlatformContext _balancePlatformContext;

        private readonly IEntityWithIdRepository<GroupDao, int> _groupRepository;

        private readonly IEntityRepository<GroupInfoDao> _groupInfoRepository;

        private readonly IMapper _mapper;

        /// <summary>
        /// Сервис работы с группами
        /// </summary>
        public GroupService()
        {
            IKernel kernel = new StandardKernel(new BalancePlatformModule());

            _balancePlatformContext = kernel.Get<BalancePlatformContext>();

            _groupRepository = kernel.Get<IEntityWithIdRepository<GroupDao, int>>(new ConstructorArgument("context", _balancePlatformContext));

            _groupInfoRepository = kernel.Get<IEntityRepository<GroupInfoDao>>(new ConstructorArgument("context", _balancePlatformContext));

            _mapper = kernel.Get<IMapper>();
        }

        /// <summary>
        /// Возвращает интерфейс для запроса групп
        /// </summary>
        /// <returns>Интерфейс для запроса групп</returns>
        public IQueryable<Group> GetQueryable()
        {
            var groupQueryable = _groupRepository.GetQueryable();
            return _mapper.ProjectTo<Group>(groupQueryable);
        }

        /// <summary>
        /// Получить список групп с подробной информацией
        /// </summary>
        /// <returns></returns>
        public List<GroupRating> GetGroupsList()
        {
            var groupsInfo = _groupInfoRepository.GetQueryable()
                .ToList();

            var groupScores = _groupRepository.GetQueryable()
                .Select(x => new GroupScore() 
                { 
                    GroupId = x.Id, 
                    Score = x.GroupScore 
                }).OrderByDescending(x => x.Score)
                .ToList();

            return groupsInfo.Select(x => new GroupRating() 
            { 
                Id = x.Id,
                Description = x.Description,
                ImgUrl = x.ImageUrl,
                Title = x.Name,
                UsersCount = x.UsersCount,
                Defeats = x.Defeats,
                Draws = x.Draws,
                Wins = x.Wins,
                PlaceOnTop = groupScores.FindIndex(p => p.GroupId == x.Id) + 1
            }).ToList();
        }
    }
}
