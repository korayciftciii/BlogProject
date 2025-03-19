using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Services.Contracts;

namespace MvcLayer.Components
{
  
    public class FeauturedPostsViewComponent :ViewComponent
    {
        private readonly IServiceManager _serviceManager;
        public FeauturedPostsViewComponent(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var blogs = await _serviceManager.BlogService.GetAllBlogAsync(false);
            var latestBlogs = blogs
              .OrderByDescending(b => b.BlogDate) // Tarihe göre sıralama (yeniden eskiye)
               .Take(5) // Son 5 blogu al
              .ToList();
            return View(latestBlogs);
        }
    }
}
