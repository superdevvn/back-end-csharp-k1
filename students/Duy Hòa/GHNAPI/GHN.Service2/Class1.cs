//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;

//namespace GHN.Service2
//{
//    public class Service
//    {
//        static async Task<Order> GetOrderAsync()
//        {
//            HttpResponseMessage response = await client.PostAsJsonAsync(
//                "GetOrderInfo", order);
//            if (response.IsSuccessStatusCode)
//            {
//                order = await response.Content.ReadAsAsync<Order>();
//            }
//            return order;
//        }
//    }
//}
