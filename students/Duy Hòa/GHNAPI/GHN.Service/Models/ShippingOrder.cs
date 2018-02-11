using System;
using System.Collections.Generic;

namespace GHN.Service.Models
{
    public class ShippingOrderCost
    {
        public int ServiceID { get; set; }
        public int ServiceType { get; set; }
    }

    public class ShippingOrder
    {
        public string token { get; set; }
        public int PaymentTypeID { get; set; }
        public int FromDistrictID { get; set; }
        public string FromWardCode { get; set; }
        public int ToDistrictID { get; set; }
        public string ToWardCode { get; set; }
        public string ClientContactName { get; set; }
        public string ClientContactPhone { get; set; }
        public string ClientAddress { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string ShippingAddress { get; set; }
        public string NoteCode { get; set; }
        public int ClientHubID { get; set; }
        public int ServiceID { get; set; }
        public int Weight { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int InsuranceFee { get; set; }
        public int CoDAmount { get; set; }
        public string Note { get; set; }
        public string SealCode { get; set; }
        public string ExternalCode { get; set; }
        public double ToLatitude { get; set; }
        public double ToLongitude { get; set; }
        public double FromLat { get; set; }
        public double FromLng { get; set; }
        public string Content { get; set; }
        public string CouponCode { get; set; }
        public bool CheckMainBankAccount { get; set; }
        public ShippingOrderCost[] ShippingOrderCosts { get; set; }
        public string ReturnContactName { get; set; }
        public string ReturnContactPhone { get; set; }
        public string ReturnAddress { get; set; }
        public string ReturnDistrictCode { get; set; }
        public string ExternalReturnCode { get; set; }
        public bool IsCreditCreate { get; set; }

        public ShippingOrder()
        {
        }
    }

    public class OrderResult
    {
        public int OrderID { get; set; }
        public int PaymentTypeID { get; set; }
        public string OrderCode { get; set; }
        public int CurrentStatus { get; set; }
        public double ExtraFee { get; set; }
        public double TotalServiceFee { get; set; }
        public DateTime ExpectedDeliveryTime { get; set; }
        public int ClientHubID { get; set; }
        public string SortCode { get; set; }
    }

    public class CreateOrderResult
    {
        public int code { get; set; }
        public string msg { get; set; }
        public OrderResult data { get; set; }
    }
}
