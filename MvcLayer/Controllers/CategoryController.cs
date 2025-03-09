using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace MvcLayer.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IServiceManager _serviceManager;
        public CategoryController(IServiceManager serviceManager)
        {
            _serviceManager=serviceManager;
        }
        public async Task<IActionResult>  Index()
        {
            var categories = await _serviceManager.CategoryService.GetAllCategoriesAsync(false);

            return View(categories);
        }

        public async Task<IActionResult> CategoryDetail([FromQuery(Name ="categoryId")]int categoryId)
        {
            var blogs = await _serviceManager.BlogService.GetAllBlogAsync(false);
            var filteredBlogs = blogs.Where(a => a.CategoryId.Equals(categoryId)); // Filtrelenmiş sonuçları listeye çeviriyoruz.
            return View(filteredBlogs);
        }
    }
}
