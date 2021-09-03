

namespace BalancePlatform.Backend.Domain.Options
{
    public class BalancePlatformOptions
    {
        public BalancePlatformOptions()
        {
        }

        public BalancePlatformOptions(BalancePlatformOptions options)
        {
            PathToStorageLocation = options.PathToStorageLocation;
        }

        public string PathToStorageLocation { get; set; }
    }
}
