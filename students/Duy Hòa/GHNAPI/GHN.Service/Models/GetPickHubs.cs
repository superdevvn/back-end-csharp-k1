using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GHN.Service.Models
{
    public class ClientHubInfo
    {
        public long PickHubID { get; set; }
        public string Address { get; set; }
        public string DistrictCode { get; set; }
        public string DistrictName { get; set; }
        public bool IsMain { get; set; }
    }

    public class GetPickHubsResult
    {
        public List<ClientHubInfo> HubInfo { get; set; }
        public string ErrorMessage { get; set; }
        public string SessionToken { get; set; }
    }
}
