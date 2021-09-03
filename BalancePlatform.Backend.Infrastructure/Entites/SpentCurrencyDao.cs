
namespace BalancePlatform.Backend.Infrastructure.Entites
{
    public class SpentCurrencyDao : EntityDao
    {
        public int UserId { get; set; }
        public UserDao User { get; set; }

        public int Value { get; set; }

    }
}
