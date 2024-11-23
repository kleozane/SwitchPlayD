using Microsoft.AspNetCore.Mvc;
using SwitchPlayD.Data;
using SwitchPlayD.Models.Category;
using SwitchPlayD.Models.Studio;
using SwitchPlayD.Services.Abstract;

namespace SwitchPlayD.Controllers
{
	public class StudioController : Controller
	{
		private readonly IStudioService _studioService;
		private readonly ICategoryService _categoryService;

		public StudioController(IStudioService studioService, ICategoryService categoryService)
		{
			_studioService = studioService;
			_categoryService = categoryService;
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
			if (ModelState.IsValid)
			{
				Studio studio = new Studio
				{
					Name = model.Name,
					Description = model.Description,
					Logo = model.Logo
				};
				await _studioService.CreateStudioAsync(studio);
				return RedirectToAction("Index");
			}
			else
			{
				return View(model);
			}
		}

		//[HttpGet]
		//public async Task<IActionResult> Edit(int id)
		//{
		//	var category = await _categoryService.GetCategoryAsync(id);
		//	var model = new StudioForModification
		//	{
		//		Id = category.Id,
		//		Name = category.Name,
		//		Description = category.Description
		//	};
		//	return View(model);
		//}

		//[HttpPost]
		//public async Task<IActionResult> Edit(StudioForModification model)
		//{
		//	if (ModelState.IsValid)
		//	{
		//		Category cat = new Category
		//		{
		//			Id = model.Id,
		//			Name = model.Name,
		//			Description = model.Description
		//		};
		//		await _categoryService.UpdateCategoryAsync(cat);
		//		return RedirectToAction("Index");
		//	}
		//	else
		//	{
		//		return View(model);
		//	}
		//}

		//public async Task<IActionResult> Delete(int id)
		//{
		//	await _categoryService.DeleteCategory(id);
		//	return RedirectToAction("Index");
		//}
	}
}
