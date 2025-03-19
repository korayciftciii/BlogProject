using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace MvcLayer.Components
{
    public class AuthorBlogsSideBarViewComponent :ViewComponent
    {
        private readonly IServiceManager _serviceManager;
        public AuthorBlogsSideBarViewComponent(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(int authorId)
        {
            var blogs = await _serviceManager.BlogService.GetAllBlogAsync(false);
            var filteredBlogs = blogs.Where(a => a.AuthorId.Equals(authorId)).OrderByDescending(b => b.BlogDate).Take(5).ToList();
            return View(filteredBlogs);
        }
    }
}
