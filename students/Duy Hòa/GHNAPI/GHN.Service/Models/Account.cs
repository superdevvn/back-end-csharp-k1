using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GHN.Service.Models
{
    public class Account
    {
        public string ApiKey { get; set; }
        public string ApiSecretKey { get; set; }
        public int ClientID { get; set; }
        public string Password { get; set; }
    }
}
