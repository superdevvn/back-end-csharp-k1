using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GHN.Service.Models
{
    public class Hub
    {
        public string Address { get; set; }

        public string ContactName { get; set; }

        public string ContactPhone { get; set; }

        public int DistrictID { get; set; }

        public string DistrictName { get; set; }

        public string Email { get; set; }

        public string FullAddress { get; set; }

        public int HubID { get; set; }

        public bool IsEditHub { get; set; }

        public bool IsMain { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int ProvinceID { get; set; }

        public string ProvinceName { get; set; }
    }

    public class GetHubsResult
    {
        public int code { get; set; }
        public string msg { get; set; }
        public List<Hub> data { get; set; }
    }
}
