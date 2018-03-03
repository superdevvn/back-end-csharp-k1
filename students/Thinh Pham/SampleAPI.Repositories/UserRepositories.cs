using SampleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAPI.Repositories
{
    public class UserRepositories
    {
        public USer Create (USer user)
        {
            using (var context = new SampleAPIDBContext())
            {
                user.Id = Guid.NewGuid();
                context.Users.Add(user);
                context.SaveChanges();
                return context.Users.Find(user.Id);
            }
        }
        public List<USer> GetUser()
        {
            using (var context = new SampleAPIDBContext())
                return context.Users.ToList();
                //{
                //    Id = user.Id,
                //    FullName = user.FullName,
                //    Username = user.Username,
                //    Password = user.Password
                //}).ToList();
        }
        public USer GetUserById(Guid id)
        {
            using (var context = new SampleAPIDBContext())
                return context.Users.Find(id);
        }
        public void Delete(Guid id)
        {
            using (var context = new SampleAPIDBContext())
            {
                var entity = context.Users.Find(id);
                context.Users.Remove(entity);
                context.SaveChanges();
            }
        }
    }
}
