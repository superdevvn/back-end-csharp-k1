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
        public DateTime CreatedDate { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime CODCollectDate { get; set; }
        public DateTime CODTransferDate { get; set; }
        public DateTime PaidDate { get; set; }
        public int CircleID { get; set; }
        //public int ClientID { get; set; }
        public int ClientHubID { get; set; }
        public int NumPick { get; set; }
        public int NumDeliver { get; set; }
        public int NumReturn { get; set; }
        public string CurrentWarehouseName { get; set; }
        public string PickWarehouseName { get; set; }
        public string DeliveryWarehouseName { get; set; }
        public double Weight { get; set; }
        public double TotalServiceCost { get; set; }
        public double TotalExtraFee { get; set; }
        public double CoDAmount { get; set; }
        public DateTime StartPickTime { get; set; }
        public DateTime EndPickTime { get; set; }
        public DateTime StartReturnTime { get; set; }
        public DateTime EndReturnTime { get; set; }
        public string ReturnInfo { get; set; }
        public DateTime StartDeliveryTime { get; set; }
        public DateTime EndDeliveryTime { get; set; }
        public DateTime ExpectedDeliveryTime { get; set; }
        public DateTime FirstDeliveredTime { get; set; }
        public int PickUser { get; set; }
        public int DeliverUser { get; set; }
        public string DeliveryUserPhone { get; set; }
        public int ReturnUser { get; set; }
        public string Note { get; set; }
        public string Content { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string SessionToken { get; set; }
        public string ErrorMessage { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
    public class ShippingOrder
    {
        public int ClientID { get; set; }
        public string Password { get; set; }
        public string ClientOrderCode { get; set; }
        public string GHNOrderCode { get; set; }
        public string SealCode { get; set; }
        public int PickHubID { get; set; }
        public string FromWardCode { get; set; }
        public string RecipientName { get; set; }
        public string RecipientPhone { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryDistrictCode { get; set; }
        public string ToWardCode { get; set; }
        public double CODAmount { get; set; }
        public int ServiceID { get; set; }
        public double Weight { get; set; }
        public string ContentNote { get; set; }
        public string ClientNote { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool IsDropOff { get; set; }
        public string ApiKey { get; set; }
        public string ApiSecretKey { get; set; }
        public double InsuranceFee { get; set; }
        public long PickupTime { get; set; }

        public string OrderCode { get; set; }
        public string OrderCodes60P { get; set; }
        public double TotalFee { get; set; }
        public string SessionToken { get; set; }
        public string ErrorMessage { get; set; }

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

                //get order
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

                //---------------------------create shipping order
                ShippingOrder so = new ShippingOrder
                {
                    ApiKey = "dSLjeJstcjwcbcLe",
                    ApiSecretKey = "F7BB3C08E9BCA7E8D880B3D9D57FB4DF",
                    ClientID = 22645,
                    Password = "NCgJRCksCCsg23hSe",
                    PickHubID = 40148,
                    FromWardCode = "1A0301",
                    RecipientName = "Nguyễn Dương Hoàng Vũ",
                    RecipientPhone = "0908626483",
                    DeliveryAddress = "214 Bắc Hải",
                    DeliveryDistrictCode = "0210",
                    ToWardCode = "1A0101",
                    ContentNote = "SC145626404073 | SP: 1x Bút E-pen (Xanh - Vàng) Mã SP: E-pen",
                    ClientNote = "Không cho thử hàng",
                    Weight = 100,
                    Length = 10,
                    Width = 10,
                    Height = 10,
                    ServiceID = 53320,
                    InsuranceFee = 2000000,
                    IsDropOff = false,
                    PickupTime = 1501804800
                };
                ShippingOrder result2 = await CreateShippingOrder(so);
                Console.WriteLine(result2);


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
        static async Task<ShippingOrder> CreateShippingOrder(ShippingOrder so)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "CreateShippingOrder", so);
            if (response.IsSuccessStatusCode)
            {
                so = await response.Content.ReadAsAsync<ShippingOrder>();
            }
            return so;
        }
        static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();
        }
    }
}

