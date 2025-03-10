using AutoMapper;
using Entities.DataTransferObject;
using Entities.Models;
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewComment([FromForm] CommentDtoForInsertion commentDto)
        {
            if (ModelState.IsValid)
            {
              await  _serviceManager.CommentService.CreateOneCommentAsync(commentDto);

                // Aynı sayfaya geri dön
                return RedirectToAction("GetBlogDetails", new { blogId = commentDto.BlogId });
            }

            // Eğer valid değilse, sayfayı tekrar göster ve hataları yansıt
            return View("GetBlogDetails", await _serviceManager.BlogService.GetBlogByIdAsync(commentDto.BlogId, false));
        }
    }
}
