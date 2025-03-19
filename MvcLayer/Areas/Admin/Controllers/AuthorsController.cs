using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace MvcLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthorsController : Controller
    {
        private readonly IServiceManager _serviceManager;
        public AuthorsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        public async Task<IActionResult> Index()
        {
            var authors =await _serviceManager.AuthorService.GetAllAuthorsAsync(false);
            return View(authors);
        }
        public async Task<IActionResult> AuthorDetails([FromQuery(Name ="authorId")]int Id)
        {
            var author = await _serviceManager.AuthorService.GetAuthorByIdAsync(Id, false);
            return View(author);
        }
    }
}
