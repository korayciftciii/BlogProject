using AutoMapper;
using Entities.DataTransferObject;
using Ganss.Xss;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MvcLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly IServiceManager _serviceManager;
        private readonly IMapper _mapper;
    

        public BlogController(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;

        }
        public async Task<IActionResult>  Index()
        {
            var blogs = await _serviceManager.BlogService.GetAllBlogAsync(false);
            return View(blogs);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteBlog([FromQuery(Name ="blogId")]int blogId)
        {
            var blog = await _serviceManager.BlogService.GetBlogByIdAsync(blogId, false);
            if (blog is not null)
            {
                await _serviceManager.BlogService.DeleteOneBlogAsync(blogId, false);
                return RedirectToAction("Index");
            }
            else
                throw new ArgumentNullException();
        }


        public async Task<IActionResult> NewBlog()
        {
            ViewBag.Categories =new SelectList(await _serviceManager.CategoryService.GetAllCategoriesAsync(false),"CategoryId","CategoryName");
            ViewBag.Authors=new  SelectList(await _serviceManager.AuthorService.GetAllAuthorsAsync(false),"AuthorId","AuthorName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewBlog([FromForm] BlogDtoForInsertion blogDto, IFormFile file)
        {
            var _santizier = new HtmlSanitizer();
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "Blog", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                blogDto.BlogImageUrl = String.Concat("/images/Blog/", file.FileName);
                 _santizier.Sanitize(blogDto.BlogContent);
                await _serviceManager.BlogService.CreateOneBlogAsync(blogDto);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public async Task<IActionResult> UpdateBlog([FromQuery(Name ="blogId")]int blogId)
        {
            ViewBag.Categories = new SelectList(await _serviceManager.CategoryService.GetAllCategoriesAsync(false), "CategoryId", "CategoryName");
            ViewBag.Authors = new SelectList(await _serviceManager.AuthorService.GetAllAuthorsAsync(false), "AuthorId", "AuthorName");
            var model = await _serviceManager.BlogService.GetBlogByIdAsync(blogId, false);
            var entity = _mapper.Map<BlogDtoForUpdate>(model);
            return View(entity);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateBlog([FromForm] BlogDtoForUpdate blogDto, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                // Eğer DTO içinde BlogId varsa, doğrudan onu kullan.
                int blogId = blogDto.BlogId;

                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "Blog", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                blogDto.BlogImageUrl = String.Concat("/images/Blog/", file.FileName);

                // Güncelleme servisine blogId'yi gönderiyoruz
                await _serviceManager.BlogService.UpdateOneBlogAsync(blogId, blogDto, true);

                return RedirectToAction("Index");
            }

            return View(blogDto);
        }


        public async Task<IActionResult> GetComments([FromQuery(Name ="blogId")]int blogId)
        {
            var comments = await _serviceManager.CommentService.GetCommentsByIdAsync(blogId, false);
            return View(comments.OrderByDescending(a=>a.CommentDate));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteComment([FromQuery(Name = "commentId")] int commentId)
        {
            var comment = await _serviceManager.CommentService.GetOneCommentByIdAsync(commentId, false);
            if (comment is not null)
            {
                await _serviceManager.CommentService.DeleteOneCommentAsync(commentId, false);
                return RedirectToAction("Index");
            }
            else
                throw new ArgumentNullException();
        }

    }
}

