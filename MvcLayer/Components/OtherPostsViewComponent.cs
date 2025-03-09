using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Services.Contracts;

namespace MvcLayer.Components
{
    public class OtherPostsViewComponent :ViewComponent
    {
        private readonly IServiceManager _serviceManager;
        public OtherPostsViewComponent(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var blogs = await _serviceManager.BlogService.GetAllBlogAsync(false);
            var randomBlogs = blogs
                .OrderBy(b => Guid.NewGuid()) // Rastgele sıralama
                .Take(5) // 5 tanesini al
                .ToList();

            return View(randomBlogs);
        }
    }
}
