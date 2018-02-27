using System.Collections.Generic;

namespace GHN.Service.Models
{
    public class District
    {
        public string Code { get; set; }
        public int DistrictID { get; set; }
        public string DistrictName { get; set; }
        public bool IsRepresentative { get; set; }
        public string MiningText { get; set; }
        public int Priority { get; set; }
        public int ProvinceID { get; set; }
        public int SupportType { get; set; }
        public int Type { get; set; }
    }

    public class GetDistrictsResult
    {
        public int code { get; set; }
        public string msg { get; set; }
        public List<District> data { get; set; }
    }
}
