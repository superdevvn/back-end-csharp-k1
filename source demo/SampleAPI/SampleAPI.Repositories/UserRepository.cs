using System;
using System.Collections.Generic;
using System.Linq;
using SampleAPI.Models;

namespace SampleAPI.Repositories
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

        public List<User> GetUsers()
        {
            using (var context = new SampleAPIDbContext())
            {
                return context.Users.ToList();
            }
        }

        public User GetUser(Guid id)
        {
            using (var context = new SampleAPIDbContext())
            {
                return context.Users.Find(id);
            }
        }
    }
}
