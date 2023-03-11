using Microsoft.Extensions.Configuration;

namespace Dobany.Configuration
{
    public interface IAppConfigurationAccessor
    {
        IConfigurationRoot Configuration { get; }
    }
}
