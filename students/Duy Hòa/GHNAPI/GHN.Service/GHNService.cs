using System;
using System.IO;
using System.Net;
using System.Text;
using GHN.Service.Models;
using Newtonsoft.Json;

namespace GHN.Service
{
    public class GHNService
    {
        private string url = "http://api.serverapi.host/api/v1/apiv3/";
        private string token = "TokenTest";
        public GHNService()
        {
        }

        private Account GetAcountInfo()
        {
            using (StreamReader streamReader = new StreamReader("account.json"))
            {
                string json = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<Account>(json);
            }
        }

        public GetDistrictProvinceDataResult GetDistrictProvinceData()
        {
            var request = (HttpWebRequest)WebRequest.Create(url + "GetDistrictProvinceData");
            var accountInfo = GetAcountInfo();
            var postData = string.Format("ApiKey={0}&ApiSecretKey={1}&ClientID={2}&Password={3}", accountInfo.ApiKey, accountInfo.ApiSecretKey, accountInfo.ClientID, accountInfo.Password);
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
            return JsonConvert.DeserializeObject<GetDistrictProvinceDataResult>(responseString);
        }

        public GetHubsResult GetHubs()
        {
            var request = (HttpWebRequest)WebRequest.Create("http://api.serverapi.host/api/v1/apiv3/GetHubs");
            var postData = string.Format("token={0}", token);
            var data = Encoding.UTF8.GetBytes(postData);
            request.Method = "POST";
            request.Accept = "application/json, text/plain, */*";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.132 Safari/537.36";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    Console.WriteLine("Won't get here");
                }
            }
            catch (WebException e)
            {
                using (WebResponse response = e.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                    using (Stream stream = response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                    {
                        string text = reader.ReadToEnd();
                        Console.WriteLine(text);
                    }
                }
            }

            //var response = (HttpWebResponse)request.GetResponse();
            //var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return new GetHubsResult();
            //return JsonConvert.DeserializeObject<GetHubsResult>(responseString);
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

        public CreateShippingOrderResult CreateShippingOrder(ShippingOrder so)
        {
            var request = (HttpWebRequest)WebRequest.Create(url + "/CreateShippingOrder");
            var accountInfo = GetAcountInfo();
            var postData = string.Format("ApiKey={0}&ApiSecretKey={1}&ClientID={2}&Password={3}&PickHubID={4}&FromWardCode={5}&RecipientName={6}&RecipientPhone={7}&DeliveryAddress={8}&DeliveryDistrictCode={9}&ToWardCode={10}&ContentNote={11}&ClientNote={12}&Weight={13}&Length={14}&Width={15}&Height={16}&ServiceID={17}&InsuranceFee={18}&IsDropOff={19}&PickupTime={20}",
                accountInfo.ApiKey,
                accountInfo.ApiSecretKey,
                accountInfo.ClientID,
                accountInfo.Password,
                so.PickHubID,
                so.FromWardCode,
                so.RecipientName,
                so.RecipientPhone,
                so.DeliveryAddress,
                so.DeliveryDistrictCode,
                so.ToWardCode,
                so.ContentNote,
                so.ClientNote,
                so.Weight,
                so.Length,
                so.Width,
                so.Height,
                so.ServiceID,
                so.InsuranceFee,
                so.IsDropOff,
                so.PickupTime.Ticks);

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
            return JsonConvert.DeserializeObject<CreateShippingOrderResult>(responseString);
        }
    }
}
