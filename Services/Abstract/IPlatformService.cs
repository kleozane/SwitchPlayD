using SwitchPlayD.Data;

namespace SwitchPlayD.Services.Abstract
{
    public interface IPlatformService
    {
        Task<IEnumerable<Platform>> GetAllPlatformsAsync();
    }
}
