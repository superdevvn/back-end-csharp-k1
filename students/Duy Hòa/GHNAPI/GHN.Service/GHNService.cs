using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using GHN.Service.Models;
using Newtonsoft.Json;

namespace GHN.Service
{
    public class GHNService
    {
        private HttpClient httpClient = new HttpClient();
        private string url = "http://api.serverapi.host/api/v1/apiv3/";
        private string token = "TokenTest";
        public GHNService()
        {
            httpClient.BaseAddress = new Uri(url + "GetHubs");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private Account GetAcountInfo()
        {
            using (StreamReader streamReader = new StreamReader("account.json"))
            {
                string json = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<Account>(json);
            }
        }        

        public async Task<GetHubsResult> GetHubs()
        {
            HttpResponseMessage response = await httpClient.PostAsJsonAsync("GetHubs", new { token = token });
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<GetHubsResult>();
            }
            return null;
        }

        public async Task<GetDistrictsResult> GetDistricts()
        {
            HttpResponseMessage response = await httpClient.PostAsJsonAsync("GetDistricts", new { token = token });
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<GetDistrictsResult>();
            }
            return null;
        }

        public async Task<CreateOrderResult> CreateOrder(ShippingOrder so)
        {
            so.token = token;
            HttpResponseMessage response = await httpClient.PostAsJsonAsync("CreateOrder", so);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<CreateOrderResult>();
                return result;
            }
            return null;
        }

        public GetOrderInfoResult GetOrderInfo(string orderCode)
        {
            var request = (HttpWebRequest)WebRequest.Create(url + "GetOrderInfo");
            var accountInfo = GetAcountInfo();
            var postData = string.Format("ApiKey={0}&ApiSecretKey={1}&ClientID={2}&Password={3}&OrderCode={4}", accountInfo.ApiKey, accountInfo.ApiSecretKey, accountInfo.ClientID, accountInfo.Password, orderCode);
            var data = Encoding.ASCII.GetBytes(postData);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return JsonConvert.DeserializeObject<GetOrderInfoResult>(responseString);
        }
    }
}
