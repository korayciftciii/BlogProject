using Microsoft.AspNetCore.Mvc;

namespace MvcLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GalleryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
