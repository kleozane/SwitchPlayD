using Microsoft.AspNetCore.Mvc;
using SwitchPlayD.Services.Abstract;

namespace SwitchPlayD.Controllers
{
	public class PlatformController : Controller
	{
		private readonly IPlatformService _platformService;

		public PlatformController(IPlatformService platformService)
		{
			_platformService = platformService;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var platforms = await _platformService.GetAllPlatformsAsync();
			return View(platforms);
		}
	}
}
