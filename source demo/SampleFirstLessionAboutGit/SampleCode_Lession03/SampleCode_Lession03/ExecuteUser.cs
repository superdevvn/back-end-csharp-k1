using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCode_Lession03
{
    public class ExecuteUser
    {
        static UserRepository userRepository = new UserRepository();
        public static void getList()
        {
            var users = userRepository.getList();
            foreach(var user in users)
            {
                Console.WriteLine("Username : {0}", user.Username);
                Console.WriteLine("CreateName : {0}", user.Creator);
                Console.WriteLine("RoleName : {0}", user.RoleName);
                Console.WriteLine("**************************************");
            }
        }
    }
}
