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
            ShippingOrderCost[] shippingOrderCosts = new ShippingOrderCost[1];
            shippingOrderCosts[0] = new ShippingOrderCost
            {
                ServiceID = 53332,
                ServiceType = 5
            };
            so.token = token;
            HttpResponseMessage response = await httpClient.PostAsJsonAsync("CreateOrder", new
            {
                token = token,
                PaymentTypeID = 1,
                FromDistrictID = 1455,
                FromWardCode = "21402",
                ToDistrictID = 1462,
                ToWardCode = "21609",
                Note = "Tạo ĐH qua API",
                SealCode = "tem niêm phong",
                ExternalCode = "",
                ClientContactName = "client name",
                ClientContactPhone = "0987654321",
                ClientAddress = "140 Lê Trọng Tấn",
                CustomerName = "Nguyễn Văn A",
                CustomerPhone = "01666666666",
                ShippingAddress = "137 Lê Quang Định",
                CoDAmount = 1500000,
                NoteCode = "CHOXEMHANGKHONGTHU",
                InsuranceFee = 0,
                ClientHubID = 0,
                ServiceID = 53319,
                ToLatitude = 1.2343322,
                ToLongitude = 10.54324322,
                FromLat = 1.2343322,
                FromLng = 10.54324322,
                Content = "Test nội dung",
                CouponCode = "",
                Weight = 10200,
                Length = 10,
                Width = 10,
                Height = 10,
                CheckMainBankAccount = false,
                ShippingOrderCosts = shippingOrderCosts,
                ReturnContactName = "",
                ReturnContactPhone = "",
                ReturnAddress = "",
                ReturnDistrictCode = "",
                ExternalReturnCode = "",
                IsCreditCreate = true
            });
            //HttpResponseMessage response = await httpClient.PostAsJsonAsync("CreateOrder", new
            //{
            //    token = token,
            //    PaymentTypeID = so.PaymentTypeID,
            //    FromDistrictID = so.FromDistrictID,
            //    FromWardCode = so.FromWardCode,
            //    ToDistrictID = so.ToDistrictID,
            //    ToWardCode = so.ToWardCode,
            //    Note = so.ToWardCode,
            //    SealCode = so.SealCode,
            //    ExternalCode = so.ExternalCode,
            //    ClientContactName = so.ClientContactName,
            //    ClientContactPhone = so.ClientContactPhone,
            //    ClientAddress = so.ClientAddress,
            //    CustomerName = so.CustomerName,
            //    CustomerPhone = so.CustomerPhone,
            //    ShippingAddress = so.ShippingAddress,
            //    CoDAmount = so.CoDAmount,
            //    NoteCode = so.NoteCode,
            //    InsuranceFee = so.InsuranceFee,
            //    ClientHubID = so.ClientHubID,
            //    ServiceID = so.ServiceID,
            //    ToLatitude = so.ToLatitude,
            //    ToLongitude = so.ToLongitude,
            //    FromLat = so.FromLat,
            //    FromLng = so.FromLng,
            //    Content = so.Content,
            //    CouponCode = so.CouponCode,
            //    Weight = so.Weight,
            //    Length = so.Length,
            //    Width = so.Width,
            //    Height = so.Height,
            //    CheckMainBankAccount = so.CheckMainBankAccount,
            //    ShippingOrderCosts = so.ShippingOrderCosts,
            //    ReturnContactName = so.ReturnContactName,
            //    ReturnContactPhone = so.ReturnContactPhone,
            //    ReturnAddress = so.ReturnAddress,
            //    ReturnDistrictCode = so.ReturnDistrictCode,
            //    ExternalReturnCode = so.ExternalReturnCode,
            //    IsCreditCreate = so.IsCreditCreate
            //});
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
