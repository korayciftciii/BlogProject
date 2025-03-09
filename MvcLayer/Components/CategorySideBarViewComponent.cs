using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace MvcLayer.Components
{
    public class CategorySideBarViewComponent :ViewComponent
    {
        private readonly IServiceManager _serviceManager;
        public CategorySideBarViewComponent(IServiceManager serviceManager)
        {
            _serviceManager=serviceManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _serviceManager.CategoryService.GetAllCategoriesAsync(false);
            return View(categories);
        }
    }
}
