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


    }
}
