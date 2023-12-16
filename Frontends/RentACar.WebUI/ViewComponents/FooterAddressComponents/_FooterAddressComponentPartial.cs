using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACar.Dto.AboutDtos;
using RentACar.Dto.FooterAddressDtos;

namespace RentACar.WebUI.ViewComponents.FooterAddressComponents
{
    public class _FooterAddressComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _FooterAddressComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient(); // istekte bulunabilmek için bir istemci oluşturdum.
            var responseMessage = await client.GetAsync("https://localhost:7286/api/FooterAddreses");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); // responseMessage içeriğinden gelen api'de ki veriyi string formatta oku.
                var values = JsonConvert.DeserializeObject<List<FooterAddressListDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
