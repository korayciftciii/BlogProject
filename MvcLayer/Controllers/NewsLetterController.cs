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
        [HttpPost]
        public async Task<PartialViewResult> Subscribe([FromForm] SubscribeMailDtoForInsertion subscribeDto)
        {
            var model = await _serviceManager.SubscribeMailService.CreateOneSubscribeAsync(subscribeDto);

            if (model != null)
            {
                // Başarılı abonelik işlemi
                TempData["SuccessMessage"] = "Abonelik başarıyla tamamlandı!";
                return PartialView();
            }
            else
            {
                // Eğer model null dönerse (hata veya kayıt başarısız)
                TempData["ErrorMessage"] = "Abonelik sırasında bir hata oluştu. Lütfen tekrar deneyin.";
                return PartialView();
            }
        }

    }
}
