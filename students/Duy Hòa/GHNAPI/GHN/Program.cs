using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GHN.Service;
using GHN.Service.Models;

namespace GHN
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();
            Console.ReadLine();
        }
        static async Task RunAsync()
        {
            GHNService service = new GHNService();

            // GetHubs
            Console.WriteLine("[GET HUBS API]");
            var hubs = await service.GetHubs();
            Console.WriteLine(string.Format("Status code: {0}", hubs.code));
            Console.WriteLine(string.Format("Data length: {0}", hubs.data.Count));
            Console.WriteLine("*******************************");

            //GetDistricts

            Console.WriteLine("[GET DISTRICTS API]");
            var districts = await service.GetDistricts();
            Console.WriteLine(string.Format("Status code: {0}", districts.code));
            Console.WriteLine(string.Format("Data length: {0}", districts.data.Count));
            Console.WriteLine("*******************************");

            //CreateOrder
            ShippingOrderCost[] shippingOrderCosts = new ShippingOrderCost[1];
            shippingOrderCosts[0] = new ShippingOrderCost
            {
                ServiceID = 53332,
                ServiceType = 5
            };
            ShippingOrder shippingOrder = new ShippingOrder()
            {
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
            };
            Console.WriteLine("[CREATE ORDER API]");
            var order = await service.CreateOrder(shippingOrder);
            Console.WriteLine(string.Format("Status code: {0}", order.code));
            Console.WriteLine(string.Format("Order ID: {0}", order.data.OrderID));
            Console.WriteLine(string.Format("Order Code: {0}", order.data.OrderCode));
            Console.WriteLine("*******************************");
        }
    }
}

