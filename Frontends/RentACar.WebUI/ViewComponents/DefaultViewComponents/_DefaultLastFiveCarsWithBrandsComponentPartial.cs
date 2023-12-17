using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACar.Dto.CarDtos;
using RentACar.Dto.TestimonialDtos;

namespace RentACar.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultLastFiveCarsWithBrandsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultLastFiveCarsWithBrandsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7286/api/Cars/GetLastFiveCarWithBrandQueryHandler");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLastFiveCarsWithBrandsDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
