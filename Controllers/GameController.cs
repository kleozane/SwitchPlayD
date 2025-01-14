using Microsoft.AspNetCore.Mvc;
using SwitchPlayD.Data;
using SwitchPlayD.Migrations;
using SwitchPlayD.Models.Game;
using SwitchPlayD.Services.Abstract;

namespace SwitchPlayD.Controllers
{
	public class GameController : Controller
	{
		private readonly IGameService _gameService;
		private readonly IGameCategoryService _gameCategoryService;
		private readonly IGamePlatformService _gamePlatformService;
		private readonly IStudioService _studioService;
		private readonly ICategoryService _categoryService;
		private readonly IPlatformService _platformService;
		private readonly IConfiguration _configuration;
		private readonly IFileHandleService _fileHandleService;

		public GameController(IGameService gameService, IGameCategoryService gameCategoryService, IGamePlatformService gamePlatformService, IStudioService studioService, IPlatformService platformService, ICategoryService categoryService, IConfiguration configuration, IFileHandleService fileHandleService)
		{
			_gameService = gameService;
			_gameCategoryService = gameCategoryService;
			_gamePlatformService = gamePlatformService;
			_studioService = studioService;
			_categoryService = categoryService;
			_platformService = platformService;
			_configuration = configuration;
			_fileHandleService = fileHandleService;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var games = await _gameService.GetGamesAsync();
			return View(games);
		}

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			var model = new GameForCreation();

			model.Categories = await _categoryService.GetCategoriesAsync();
			model.Studios = await _studioService.GetStudiosAsync();
			model.Platforms = await _platformService.GetAllPlatformsAsync();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Create(GameForCreation model)
		{
			var file = HttpContext.Request.Form.Files.FirstOrDefault();

			var game = new Game
			{
				Title = model.Title,
				Description = model.Description,
				MagnetLink = model.MagnetLink,
				Size = model.Size,
				PublishDate = DateTime.ParseExact(model.PublishDate, "dd/MM/yyyy", null),
				Price = model.Price,
				StudioId = model.StudioId
			};

			await _gameService.CreateGameAsync(game);
			await _gameCategoryService.CreateGameCategoryAsync(game.Id, model.CategoryIds);
			await _gamePlatformService.CreateGamePlatformAsync(game.Id, model.PlatformIds);

			if (file != null)
			{
				var uploadDir = _configuration["Uploads:GamePosters"];
				var fileName = game.Id + "_" + game.Title;
				fileName = await _fileHandleService.UploadAndRenameFileAsync(file, uploadDir, fileName);
				game.Poster = fileName;
				await _gameService.UpdateGameAsync(game);
			}

			return RedirectToAction("Index");
		}

        public async Task<IActionResult> ApplyDiscount(int id, double discount)
        {
			var game = await _gameService.GetGameAsync(id);
			game.Discount = discount;
			await _gameService.UpdateGameAsync(game);

            return RedirectToAction("Index");
        }
    }
}
