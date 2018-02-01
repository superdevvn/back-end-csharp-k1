using GHN.Service.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GHN.Service
{
    public class GHNService
    {
        private HttpClient client;

        public GHNService()
        {
            client.BaseAddress = new Uri("https://testapipds.ghn.vn:9999/external/b2c/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Order> GetOrderAsync(Order order)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "GetOrderInfo", order);
            if (response.IsSuccessStatusCode)
            {
                order = await response.Content.ReadAsAsync<Order>();
            }
            return order;
        }
        public async Task<ShippingOrder> CreateShippingOrder(ShippingOrder so)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "CreateShippingOrder", so);
            if (response.IsSuccessStatusCode)
            {
                so = await response.Content.ReadAsAsync<ShippingOrder>();
            }
            return so;
        }
    }
}
