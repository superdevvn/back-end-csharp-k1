using Models;
using Models.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UserRepository
    {
        //public List<UserComplex> getList()
        //{
        //    using (var context = new SuperDevDbContext())
        //    {
        //        return context.Users.Select(entity => new UserComplex
        //        {
        //            Id = entity.Id,
        //            RoleId = entity.RoleId,
        //            RoleName = entity.Role.Name,
        //            CreatedBy = entity.CreatedBy,
        //            Creator = entity == null ? string.Empty : entity.Creator.Username,
        //            FirstName = entity.FirstName,
        //            LastName = entity.LastName,
        //            Username = entity.Username,
        //            Password = entity.Description
        //        }).ToList();
        //    }
        //}

        public User Create(User user)
        {
            using (var context = new SuperDevDbContext())
            {
                user.Id = Guid.NewGuid();
                context.Users.Add(user);
                context.SaveChanges();
                return context.Users.Find(user.Id);
            }
        }
    }
}
