using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories;

namespace SimpleCodeFirst
{
    public class ExcuteUser
    {
        static UserRepository userRepository = new UserRepository();
        public static void GetList()
        {
            var users = userRepository.GetList();
            foreach(var user in users)
            {
                Console.WriteLine(string.Format("Username: {0}, RoleName: {1}, CreatorName: {2}", user.Username, user.RoleName, user.CreatorName));
            }
        }
    }
}
