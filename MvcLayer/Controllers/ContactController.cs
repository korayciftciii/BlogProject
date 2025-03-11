using Entities.DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace MvcLayer.Controllers
{
    public class ContactController : Controller
    {
        private readonly IServiceManager _serviceManager;
        public ContactController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ContactMessage([FromForm]ContactDtoForInsertion contactDto)
        {
            if(ModelState.IsValid)
            {
                _serviceManager.ContactService.CreateContactMessage(contactDto);
                return RedirectToAction("Index");
            }
            else
                return View();
        }
    }
}
