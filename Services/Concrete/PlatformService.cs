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

        public async Task CreatePlatformAsync(Platform platform)
        {
            await _platformRepository.AddAsync(platform);
        }
        public async Task EditPlatformAsync(Platform platform)
        {
             await _platformRepository.UpdateAsync(platform);
        }
        public async Task<Platform> GetPlatformAsync(int id)
        {
           return await _platformRepository.GetAsync(id);
        }
        public async Task<IEnumerable<Platform>> GetAllPlatformAsync()
        {
            return await _platformRepository.GetAllAsync();
        }

    }
}
