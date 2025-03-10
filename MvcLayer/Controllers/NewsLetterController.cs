using Entities.DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace MvcLayer.Controllers
{
    public class NewsLetterController : Controller
    {

        private readonly IServiceManager _serviceManager;

        public NewsLetterController(IServiceManager serviceManager)
        {
           
            _serviceManager = serviceManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewSubscribe([FromForm] SubscribeMailDtoForInsertion subscribeDto)
        {
            if(ModelState.IsValid)
            {
                await _serviceManager.SubscribeMailService.CreateOneSubscribeAsync(subscribeDto);
                    
                    return RedirectToAction("Index");
                
            }
            else
            {
                // Eğer model null dönerse (hata veya kayıt başarısız)
               
                return View();
            }
    
        }

    }
}
