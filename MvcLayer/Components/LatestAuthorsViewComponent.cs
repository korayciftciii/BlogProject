using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace MvcLayer.Components
{
    public class LatestAuthorsViewComponent :ViewComponent
    {
        private readonly IServiceManager _serviceManager;
        public LatestAuthorsViewComponent(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var authors = await _serviceManager.AuthorService.GetAllAuthorsAsync(false);
            var toListLatest=authors.OrderByDescending(b=>b.AuthorInsertionDate)
                .Take(8)
                .ToList();
            
            return View(toListLatest);
        }
    }
}
