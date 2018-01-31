using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace GHN
{
    public class Order
    {
        public int ClientID { get; set; }
        public string Password { get; set; }
        public string OrderCode { get; set; }
        public string ApiKey { get; set; }
        public string ApiSecretKey { get; set; }
        public int OrderID { get; set; }
        public string OldSOCode { get; set; }
        public string ClientOrderCode { get; set; }
        public string SealCode { get; set; }
        public string StoringCode { get; set; }
        public string ReturnCode { get; set; }
        public string CurrentStatus { get; set; }
        public string LexicalOrder { get; set; }
        public string SenderName { get; set; }
        public string SenderPhone { get; set; }
        public string PickAddress { get; set; }
        public string FromDistrictCode { get; set; }
        public string FromDistrictName { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverPhone { get; set; }
        public string ShippingAddress { get; set; }
        public string ToDistrictCode { get; set; }
        public string ToDistrictName { get; set; }
        public string PaymentType { get; set; }
        public string Partner { get; set; }
        public string CircleName { get; set; }
        public string CreatedDate { get; set; }
        public string OrderDate { get; set; }
        public string UpdatedDate { get; set; }
        public string CODCollectDate { get; set; }
        public string CODTransferDate { get; set; }
        public string PaidDate { get; set; }
        public int CircleID { get; set; }
        //public int ClientID { get; set; }
        public string ClientHubID { get; set; }
        public string NumPick { get; set; }
        public string NumDeliver { get; set; }
        public string NumReturn { get; set; }
        public string CurrentWarehouseName { get; set; }
        public string PickWarehouseName { get; set; }
        public string DeliveryWarehouseName { get; set; }
        public string Weight { get; set; }
        public string TotalServiceCost { get; set; }
        public string TotalExtraFee { get; set; }
        public string CoDAmount { get; set; }
        public string StartPickTime { get; set; }
        public string EndPickTime { get; set; }
        public string StartReturnTime { get; set; }
        public string EndReturnTime { get; set; }
        public string ReturnInfo { get; set; }
        public string StartDeliveryTime { get; set; }
        public string EndDeliveryTime { get; set; }
        public string ExpectedDeliveryTime { get; set; }
        public string FirstDeliveredTime { get; set; }
        public string PickUser { get; set; }
        public string DeliverUser { get; set; }
        public string DeliveryUserPhone { get; set; }
        public string ReturnUser { get; set; }
        public string Note { get; set; }
        public string Content { get; set; }
        public string Length { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string SessionToken { get; set; }
        public string ErrorMessage { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
        class Program
    {

        static HttpClient client = new HttpClient();

        static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("https://testapipds.ghn.vn:9999/external/b2c/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                Order order = new Order
                {
                    ApiKey = "dSLjeJstcjwcbcLe",
                    ApiSecretKey = "F7BB3C08E9BCA7E8D880B3D9D57FB4DF",
                    ClientID = 22645,
                    Password = "NCgJRCksCCsg23hSe",
                    OrderCode = "157327486268"
                };
                Order result = await GetOrderAsync(order);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static async Task<Order> GetOrderAsync(Order order)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "GetOrderInfo", order);
            if (response.IsSuccessStatusCode)
            {
                order = await response.Content.ReadAsAsync<Order>();
            }
            return order;
        }
        static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();
        }
    }
}

