using SwitchPlayD.Data;
using SwitchPlayD.Repositories;
using SwitchPlayD.Services.Abstract;
using System.ComponentModel.DataAnnotations;

namespace SwitchPlayD.Services.Concrete
{
    public class PlatformService : IPlatformService
    {
        public readonly PlatformRepository _platformRepository;

        public PlatformService(PlatformRepository platformRepository)
        {
            _platformRepository = platformRepository;
        }

        public async Task<IEnumerable<Platform>> GetAllPlatformsAsync()
        {
            return await _platformRepository.GetAllAsync();
        }

    }
}
