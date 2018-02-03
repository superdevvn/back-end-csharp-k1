using SampleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleAPI.Responsiblities
{
    public class UserResponsiblity
    {
        public User Create(User user)

        {
            using (var context = new SampleAPIDBContext())
            {
                user.Id = Guid.NewGuid();
                context.Users.Add(user);
                context.SaveChanges();
                return context.Users.Find(user.Id);
            }
        }
        public List<User> getUsers(User user)
        {
            using (var context = new SampleAPIDBContext())
            {
                return context.Users.Select(entity => new User
                {
                    Id = entity.Id,
                    FullName = entity.FullName,
                    Username = entity.Username,
                    Password = entity.Password,
                }).ToList();
            }

        }
        public User GetById(Guid id)
        {
            using (var context = new SampleAPIDBContext())
            {
                return context.Users.Find(id);
            }

        }
        public void Delete(Guid id)
        {
            using (var context = new SampleAPIDBContext())
            {
                User a = context.Users.Find(id);

                context.Users.Remove(a);
                context.SaveChanges();

            }

        }


    }
}
