using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UserComplex
    {
        public Guid Id { get; set; }

        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public Guid? CreateBy { get; set; }
       
       
        public string Username { get; set; }
        
        public string Password { get; set; }
       
        public string Firstname { get; set; }
        
        public string Lastname { get; set; }
       
        public string Description { get; set; }
        public string Creator { get; set; }
    }
}
