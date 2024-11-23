using Microsoft.AspNetCore.Mvc;
using SwitchPlayD.Data;
using SwitchPlayD.Models.Category;
using SwitchPlayD.Services.Abstract;

namespace SwitchPlayD.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService) 
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new CategoryForCreation();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryForCreation model)
        {
            if (ModelState.IsValid)
            {
                Category cat = new Category
                {
                    Name = model.Name,
                    Description = model.Description
                };
                await _categoryService.CreateCategoryAsync(cat);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
            var category = await _categoryService.GetCategoryAsync(id);
			var model = new CategoryForModification
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(CategoryForModification model)
		{
			if (ModelState.IsValid)
			{
				Category cat = new Category
				{
                    Id = model.Id,
					Name = model.Name,
					Description = model.Description
				};
				await _categoryService.UpdateCategoryAsync(cat);
				return RedirectToAction("Index");
			}
			else
			{
				return View(model);
			}
		}

		public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteCategory(id);
            return RedirectToAction("Index");
        }

    }
}
