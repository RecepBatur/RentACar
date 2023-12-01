using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACar.Dto.AboutDtos;

namespace RentACar.WebUI.ViewComponents.AboutViewComponents
{
    public class _AboutUsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AboutUsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient(); // istekte bulunabilmek için bir istemci oluşturdum.
            var responseMessage = await client.GetAsync("https://localhost:7286/api/Abouts");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); // responseMessage içeriğinden gelen api'de ki veriyi string formatta oku.
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
