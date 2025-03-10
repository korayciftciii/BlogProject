using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace MvcLayer.Components
{
    public class FooterAboutContentViewComponent :ViewComponent
    {
        private readonly IServiceManager _serviceManager;
        public FooterAboutContentViewComponent(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var content = await _serviceManager.AboutService.GetAboutContentAsync(false);
            var content1 = content.FirstOrDefault()?.AboutContent1 ?? string.Empty;
            return View("Default",content1);
        }
    }
}
