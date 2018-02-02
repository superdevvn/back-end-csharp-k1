using System;
using GHN.Service;
using GHN.Service.Models;

namespace GHN
{
    class Program
    {
        static void Main(string[] args)
        {
            GHNService service = new GHNService();
            var pickHubs = service.GetPickHubs();
            Console.WriteLine(pickHubs.ErrorMessage);
            Console.WriteLine(pickHubs);
            var districtProvinceData = service.GetDistrictProvinceData();
            Console.WriteLine(districtProvinceData.ErrorMessage);
            Console.WriteLine(districtProvinceData);
            ShippingOrder shippingOrder = new ShippingOrder()
            {
                PickHubID= 40148,
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
                InsuranceFee = 2000000
            };
            var createShippingOrderResult = service.CreateShippingOrder(shippingOrder);
            Console.WriteLine(createShippingOrderResult.ErrorMessage);
            Console.WriteLine(createShippingOrderResult);

            var orderInfo = service.GetOrderInfo("123");
            Console.WriteLine(orderInfo.ErrorMessage);
            Console.WriteLine(orderInfo);
            Console.ReadLine();
        }
    }
}

