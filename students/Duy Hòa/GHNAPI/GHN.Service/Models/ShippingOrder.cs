using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHN.Service.Models
{
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
}
