using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GHN.Service.Models
{
    public class DistrictProvinceData
    {
        public string DistrictCode { get; set; }
        public string DistrictName { get; set; }
        public string ProvinceCode { get; set; }
        public string ProvinceName { get; set; }
        public int Type { get; set; }
        public int SupportType { get; set; }
    }

    public class GetDistrictProvinceDataResult
    {
        public List<DistrictProvinceData> Data { get; set; }
        public string ErrorMessage { get; set; }

        public string SessionToken { get; set; }
    }
}
