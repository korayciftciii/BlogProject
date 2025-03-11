using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace MvcLayer.Components
{
    public class PopularAuthorsViewComponent :ViewComponent
    {
        private readonly IServiceManager _serviceManager;
        public PopularAuthorsViewComponent(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var authors = await _serviceManager.AuthorService.GetAllAuthorsAsync(false);
            var randomAuthors=authors
                .OrderBy(b => Guid.NewGuid()) // Rastgele sıralama
                .Take(3) 
                .ToList();
            return View(randomAuthors);
        }

    }
}
