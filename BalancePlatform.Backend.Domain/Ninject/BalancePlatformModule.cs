using AutoMapper;
using BalancePlatform.Backend.Domain.Options;
using BalancePlatform.Backend.Domain.Services.Implementations.BalancePlatformImplementations;
using BalancePlatform.Backend.Domain.Services.Interfaces.BalancePlatformInterfaces;
using BalancePlatform.Backend.Infrastructure.Contexts;
using BalancePlatform.Backend.Infrastructure.Repositories.Implementations.BaseImplementations;
using BalancePlatform.Backend.Infrastructure.Repositories.Interfaces.BaseInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Ninject;
using Ninject.Modules;

namespace BalancePlatform.Backend.Domain.Ninject
{
    /// <summary>
    /// Модуль, который определяет привязки для системы
    /// </summary>
    public class BalancePlatformModule : NinjectModule
    {
        /// <summary>
        /// Модуль, который определяет привязки для системы
        /// </summary>
        public BalancePlatformModule()
        {
        }

        public override void Load()
        {
            AddContextBindings();
            AddRepositoryBindings();
            AddServiceBindings();

            var mapperConfiguration = CreateConfiguration();
            Bind<MapperConfiguration>().ToConstant(mapperConfiguration).InSingletonScope();

            // This teaches Ninject how to create automapper instances say if for instance
            // MyResolver has a constructor with a parameter that needs to be injected
            Bind<IMapper>().ToMethod(ctx =>
                new Mapper(mapperConfiguration, type => ctx.Kernel.Get(type)));
        }

        /// <summary>
        /// Добавляем связи реализаций сервисов и их интерфейсов
        /// </summary>
        public void AddContextBindings()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var balancePlatformConnectionString = configuration.GetConnectionString("BalancePaltformConnectionString");
            var balancePlatformOptions = configuration.GetSection("BalancePlatformOptions").Get<BalancePlatformOptions>();

            var balancePlatformOptionsBuilder = new DbContextOptionsBuilder<BalancePlatformContext>();
            var matchingOptions = balancePlatformOptionsBuilder
                .UseSqlServer(balancePlatformConnectionString)
                .Options;

            Bind<BalancePlatformOptions>().ToSelf().InTransientScope()
                .WithConstructorArgument("options", balancePlatformOptions);

            Bind<BalancePlatformContext>().ToSelf().InTransientScope()
                .WithConstructorArgument("options", matchingOptions);
        }

        /// <summary>
        /// Добавляем связи реализаций репозиториев и их интерфейсов EF контекста
        /// </summary>
        private void AddRepositoryBindings()
        {
            Bind(typeof(IEntityRepository<>)).To(typeof(EntityRepository<>));
            Bind(typeof(IEntityWithIdRepository<,>)).To(typeof(EntityWithIdRepository<,>));
            Bind(typeof(IReadOnlyEntityRepository<>)).To(typeof(ReadOnlyEntityRepository<>));
            Bind(typeof(IReadOnlyEntityWithIdRepository<,>)).To(typeof(ReadOnlyEntityWithIdRepository<,>));
        }

        /// <summary>
        /// Добавляем связи реализаций сервисов и их интерфейсов
        /// </summary>
        public void AddServiceBindings()
        {
            Bind<IAuthService>().To<AuthService>();
            Bind<IUserService>().To<UserService>();
            Bind<IRoleService>().To<RoleService>();
            Bind<IShopService>().To<ShopService>();
            Bind<IGroupService>().To<GroupService>();
            Bind<IUserForWebService>().To<UserForWebService>();
        }

        /// <summary>
        /// Создаём конфигурацию для AutoMapper
        /// </summary>
        /// <returns></returns>
        private MapperConfiguration CreateConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // Add all profiles in current assembly
                cfg.AddMaps(GetType().Assembly);
            });
            config.AssertConfigurationIsValid();

            return config;
        }
    }
}
