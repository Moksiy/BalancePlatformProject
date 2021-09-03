using BalancePlatform.Backend.Infrastructure.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BalancePlatform.Backend.Infrastructure.Contexts
{
    /// <summary>
    /// EF DbContext для подключения к БД 
    /// </summary>
    public class BalancePlatformContext : BaseDbContext
    {
        /// <summary>
        /// EF DbContext для подключения к БД
        /// </summary>
        public BalancePlatformContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BadgeDao>().ToTable("Badges", "dbo");
            modelBuilder.Entity<BattleParticipantDao>().ToTable("BattleParticipants", "dbo");
            modelBuilder.Entity<BattleRequestDao>().ToTable("BattleRequests", "dbo");
            modelBuilder.Entity<BattleDao>().ToTable("Battles", "dbo");
            modelBuilder.Entity<CurrencyDao>().ToTable("Currency", "dbo");
            modelBuilder.Entity<DailyPlanDao>().ToTable("DailyPlan", "dbo");
            modelBuilder.Entity<GoalDao>().ToTable("Goals", "dbo");
            modelBuilder.Entity<GroupBattleScoreDao>().ToTable("GroupBattleScores", "dbo");
            modelBuilder.Entity<GroupDao>().ToTable("Groups", "dbo");
            modelBuilder.Entity<GroupToUserRequestDao>().ToTable("GroupToUserRequests", "dbo");
            modelBuilder.Entity<OrderDao>().ToTable("Orders", "dbo");
            modelBuilder.Entity<ProductDao>().ToTable("Products", "dbo");
            modelBuilder.Entity<RoleDao>().ToTable("Roles", "dbo");
            modelBuilder.Entity<SpentCurrencyDao>().ToTable("SpentCurrency", "dbo");
            modelBuilder.Entity<TransactionDao>().ToTable("Transactions", "dbo");
            modelBuilder.Entity<UserBadgeDao>().ToTable("UserBadges", "dbo");
            modelBuilder.Entity<UserDao>().ToTable("Users", "dbo");
            modelBuilder.Entity<UserScoreDao>().ToTable("UserScores", "dbo");
            modelBuilder.Entity<UserToGroupRequestDao>().ToTable("UserToGroupRequests", "dbo");
            modelBuilder.Entity<UserTokenDao>().ToTable("UserTokens", "dbo");


            #region BadgeDao

            modelBuilder.Entity<BadgeDao>()
                   .Property(p => p.Id)
                   .ValueGeneratedOnAdd();

            #endregion

            #region BattleParticipantDao

            modelBuilder.Entity<BattleParticipantDao>()
                .HasKey(p => p.BattleId);

            modelBuilder.Entity<BattleParticipantDao>()
                .HasOne(p => p.Battle)
                .WithOne();

            modelBuilder.Entity<BattleParticipantDao>()
                .HasOne(p => p.AttackGroup)
                .WithMany()
                .HasForeignKey(p => p.AttackGroupId);

            modelBuilder.Entity<BattleParticipantDao>()
                .HasOne(p => p.DefenseGroup)
                .WithMany()
                .HasForeignKey(p => p.DefenseGroupId);

            #endregion

            #region BattleRequestDao

            modelBuilder.Entity<BattleRequestDao>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<BattleRequestDao>()
                .HasOne(p => p.AttackGroup)
                .WithMany()
                .HasForeignKey(p => p.AttackGroupId);

            modelBuilder.Entity<BattleRequestDao>()
                .HasOne(p => p.DefenseGroup)
                .WithMany()
                .HasForeignKey(p => p.DefenseGroupId);

            #endregion

            #region BattleDao

            modelBuilder.Entity<BattleDao>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<BattleDao>()
                .HasOne(p => p.WinnerGroup)
                .WithMany()
                .HasForeignKey(p => p.WinnerGroupId);

            #endregion

            #region CurrencyDao

            modelBuilder.Entity<CurrencyDao>()
                .HasNoKey();

            #endregion

            #region DailyPlanDao

            modelBuilder.Entity<DailyPlanDao>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<DailyPlanDao>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId);

            #endregion

            #region GoalDao

            modelBuilder.Entity<GoalDao>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<DailyPlanDao>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId);

            #endregion

            #region GroupBattleScoreDao

            modelBuilder.Entity<GroupBattleScoreDao>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<GroupBattleScoreDao>()
                .HasOne(p => p.Battle)
                .WithMany()
                .HasForeignKey(p => p.BattleId);

            modelBuilder.Entity<GroupBattleScoreDao>()
                .HasOne(p => p.Group)
                .WithMany()
                .HasForeignKey(p => p.GroupId);

            #endregion

            #region GroupDao

            modelBuilder.Entity<GroupDao>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<GroupDao>()
                .HasOne(x => x.Admin)
                .WithMany()
                .HasForeignKey(x => x.AdminId);

            #endregion

            #region GroupToUserRequestDao

            modelBuilder.Entity<GroupToUserRequestDao>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<GroupToUserRequestDao>()
                .HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<GroupToUserRequestDao>()
                .HasOne(x => x.Group)
                .WithMany()
                .HasForeignKey(x => x.GroupId);

            #endregion

            #region OrderDao

            modelBuilder.Entity<OrderDao>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<OrderDao>()
                .HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<OrderDao>()
                .HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.ProductId);

            #endregion

            #region ProductDao

            modelBuilder.Entity<ProductDao>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            #endregion

            #region RoleDao
            modelBuilder.Entity<ProductDao>().ToTable("Products", "dbo");
            modelBuilder.Entity<UserScoreDao>().ToTable("UserScores", "dbo");
            modelBuilder.Entity<GroupInfoDao>().ToView("GroupsInfo", "dbo");
            modelBuilder.Entity<GroupDao>().ToTable("Groups", "dbo");

            modelBuilder.Entity<GroupInfoDao>()
                .HasNoKey();

            modelBuilder.Entity<RoleDao>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            #endregion

            #region SpentCurrencyDao

            modelBuilder.Entity<SpentCurrencyDao>()
                .HasNoKey();

            modelBuilder.Entity<GroupDao>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<ProductDao>()
               .Property(p => p.Id)
               .ValueGeneratedOnAdd();
            modelBuilder.Entity<SpentCurrencyDao>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId);

            #endregion

            #region TransactionDao

            modelBuilder.Entity<TransactionDao>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<TransactionDao>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId);

            #endregion

            #region UserBadgeDao

            modelBuilder.Entity<UserBadgeDao>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<UserBadgeDao>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<UserBadgeDao>()
                .HasOne(p => p.Badge)
                .WithMany()
                .HasForeignKey(p => p.BadgeId);


            #endregion

            #region UserDao

            modelBuilder.Entity<UserDao>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<UserDao>()
                .HasOne(x => x.Role)
                .WithMany()
                .HasForeignKey(x => x.RoleId);

            #endregion

            #region UserScoreDao

            modelBuilder.Entity<UserScoreDao>()
                .HasKey(p => p.UserId);

            modelBuilder.Entity<UserScoreDao>()
                .HasOne(p => p.User)
                .WithOne();

            #endregion

            #region UserToGroupRequestDao

            modelBuilder.Entity<UserToGroupRequestDao>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<UserToGroupRequestDao>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<UserToGroupRequestDao>()
                .HasOne(p => p.Group)
                .WithMany()
                .HasForeignKey(p => p.GroupId);


            #endregion

            #region UserTokenDao

            modelBuilder.Entity<UserTokenDao>()
                .HasKey(p => p.Token);

            modelBuilder.Entity<UserTokenDao>()
                .HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);

            #endregion



            base.OnModelCreating(modelBuilder);
        }

        public static readonly ILoggerFactory MatchingLoggerFactory = LoggerFactory.Create(builder =>
        {
            //builder.AddDebug();
            //builder.AddConsole();
        });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(MatchingLoggerFactory);
            if (optionsBuilder.IsConfigured == false)
            {
                base.OnConfiguring(optionsBuilder);
            }
        }
    }
}
