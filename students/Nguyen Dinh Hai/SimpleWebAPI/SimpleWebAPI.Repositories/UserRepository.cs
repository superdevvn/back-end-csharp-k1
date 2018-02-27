using SimpleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleAPI.Models;

namespace SimpleWebAPI.Repositories
{
    public class UserRepository
    {
        public User Create(User user)
        {
            using (var context = new SampleAPIDbContext())
            {
                user.Id = Guid.NewGuid();
                context.Users.Add(user);
                context.SaveChanges();
                return context.Users.Find(user.Id);


            }
        }
    }
}
