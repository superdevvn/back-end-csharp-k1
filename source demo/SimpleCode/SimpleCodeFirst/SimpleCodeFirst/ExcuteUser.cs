using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCodeFirst
{
    public class ExcuteUser
    {
        static UserRepository userReposity = new UserRepository();
        public static void getList()
        {
            var users = userReposity.GetList();
            foreach(var user in users)
            {
                Console.WriteLine(string.Format("Username: {0}, CreateName: {0}, RoleName: {0}", user.Username, user.Creator, user.RoleName));
            }
        }
    }
}
