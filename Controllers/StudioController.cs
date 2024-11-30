using Microsoft.AspNetCore.Mvc;
using SwitchPlayD.Data;
using SwitchPlayD.Migrations;
using SwitchPlayD.Models.Category;
using SwitchPlayD.Models.Studio;
using SwitchPlayD.Services.Abstract;
using SwitchPlayD.Services.Concrete;

namespace SwitchPlayD.Controllers
{
	public class StudioController : Controller
	{
		private readonly IStudioService _studioService;
		private readonly ICategoryService _categoryService;
		private readonly IStudioCategoryService _studioCategoryService;

		public StudioController(IStudioService studioService, ICategoryService categoryService, IStudioCategoryService studioCategoryService)
		{
			_studioService = studioService;
			_categoryService = categoryService;
			_studioCategoryService = studioCategoryService;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var studios = await _studioService.GetStudiosAsync();
			return View(studios);
		}

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			var model = new StudioForCreation();

			var categories = await _categoryService.GetCategoriesAsync();
			model.Categories = categories;

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Create(StudioForCreation model)
		{
			Studio studio = new Studio
			{
				Name = model.Name,
				Description = model.Description,
				Logo = model.Logo
			};
			await _studioService.CreateStudioAsync(studio);
			await _studioCategoryService.CreateStudioCategoryAsync(studio.Id, model.CategoryIds);

			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var studio = await _studioService.GetStudioAsync(id);
			var categories = await _categoryService.GetCategoriesAsync();
			var sc = await _studioCategoryService.GetByStudioId(id);
			var model = new StudioForModification
			{
				Id = studio.Id,
				Name = studio.Name,
				Logo = studio.Logo,
				Description = studio.Description,
				Categories = categories,
				SelectedCategories = sc
			};
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(StudioForModification model)
		{
			if (ModelState.IsValid)
			{
				Studio studio = new Studio
				{
					Id = model.Id,
					Name = model.Name,
					Logo = model.Logo,
					Description = model.Description
				};
				await _studioService.UpdateStudioAsync(studio);
				await _studioCategoryService.CreateStudioCategoryAsync(studio.Id, model.CategoryIds);
				return RedirectToAction("Index");
			}
			else
			{
				return View(model);
			}
		}

		public async Task<IActionResult> Delete(int id)
		{
			await _studioService.DeleteStudio(id);
			return RedirectToAction("Index");
		}
	}
}
