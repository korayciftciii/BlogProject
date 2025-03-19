using Microsoft.AspNetCore.Mvc;

namespace MvcLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CalendarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
