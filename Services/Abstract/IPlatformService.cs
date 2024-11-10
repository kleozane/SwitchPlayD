using SwitchPlayD.Data;

namespace SwitchPlayD.Services.Abstract
{
    public interface IPlatformService
    {
        Task CreatePlatformAsync(Platform platform);
        Task EditPlatformAsync(Platform platform);
        Task<Platform> GetPlatformAsync(int id);
        Task<IEnumerable<Platform>> GetAllPlatformAsync();
    }
}
