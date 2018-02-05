using System;

namespace GHN.Service.Models
{
    public class GetOrderInfoResult
    {
        public int? OrderID { get; set; }
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
        public DateTime? CreatedDate { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? CODCollectDate { get; set; }
        public DateTime? CODTransferDate { get; set; }
        public DateTime? PaidDate { get; set; }
        public int? CircleID { get; set; }
        public int? ClientID { get; set; }
        public int? ClientHubID { get; set; }
        public int? NumPick { get; set; }
        public int? NumDeliver { get; set; }
        public int? NumReturn { get; set; }
        public string CurrentWarehouseName { get; set; }
        public string PickWarehouseName { get; set; }
        public string DeliveryWarehouseName { get; set; }
        public double? Weight { get; set; }
        public double? TotalServiceCost { get; set; }
        public double? TotalExtraFee { get; set; }
        public double? CoDAmount { get; set; }
        public DateTime? StartPickTime { get; set; }
        public DateTime? EndPickTime { get; set; }
        public DateTime? StartReturnTime { get; set; }
        public DateTime? EndReturnTime { get; set; }
        public string ReturnInfo { get; set; }
        public DateTime? StartDeliveryTime { get; set; }
        public DateTime? EndDeliveryTime { get; set; }
        public DateTime? ExpectedDeliveryTime { get; set; }
        public DateTime? FirstDeliveredTime { get; set; }
        public int? PickUser { get; set; }
        public int? DeliverUser { get; set; }
        public string DeliveryUserPhone { get; set; }
        public int? ReturnUser { get; set; }
        public string Note { get; set; }
        public string Content { get; set; }
        public int? Length { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public string SessionToken { get; set; }
        public string ErrorMessage { get; set; }
    }
}
