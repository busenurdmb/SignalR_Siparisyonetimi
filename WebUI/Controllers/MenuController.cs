using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Dtos.BasketDtos;
using WebUI.Dtos.ProductDtos;

namespace WebUI.Controllers
{
    public class MenuController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public MenuController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7291/api/Product");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return View(values);
        }
  
      
        [HttpPost]
        public async Task<IActionResult> AddBasket([FromBody] CreateBasketDto createBasketDto)
        {
            // createBasketDto doğrudan JavaScript kodundan JSON olarak gönderilecek

               // HttpClient oluşturulur
                using var client = _httpClientFactory.CreateClient();

                // createBasketDto JSON formatına dönüştürülür
                var jsonData = JsonConvert.SerializeObject(createBasketDto);

                // StringContent oluşturulur, JSON veriyi içerir
                var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

                // API'ye POST isteği gönderilir
                var responseMessage = await client.PostAsync("https://localhost:7291/api/Basket", stringContent);

                // İsteğin başarılı olup olmadığı kontrol edilir
                if (responseMessage.IsSuccessStatusCode)
                {
                    // Başarılıysa, Index sayfasına yönlendirilir
                    return RedirectToAction("Index");
                }
                else
                {
                    // Başarısızsa, hata mesajı döndürülür
                    return Json(new { success = false, message = "Sepete ekleme başarısız oldu." });
                }
            
        }

    }
}
