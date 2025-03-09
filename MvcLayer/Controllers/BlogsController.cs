using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace MvcLayer.Controllers
{
    public class BlogsController : Controller
    {
        private readonly IServiceManager _serviceManager;
        private readonly IMapper _mapper;
        public BlogsController(IServiceManager serviceManager,IMapper mapper)
        {
            _mapper = mapper;
            _serviceManager = serviceManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetBlogDetails([FromQuery(Name ="blogId")] int blogId)
        {
            var blog = await _serviceManager.BlogService.GetBlogByIdAsync(blogId, false);
            return blog is null ? throw new ArgumentNullException() : View(blog);
        }
    }
}
