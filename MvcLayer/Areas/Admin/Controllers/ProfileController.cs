using Microsoft.AspNetCore.Mvc;

namespace MvcLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
