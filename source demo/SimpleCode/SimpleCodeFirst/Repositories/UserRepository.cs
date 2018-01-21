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
        public List<UserComplex> GetList()
        {
            using (var context = new SuperDBContext())
            {
                return context.Users.Select(entity => new UserComplex
                {
                    Id = entity.Id,
                    RoleId = entity.RoleId,
                    RoleName = entity.Role.Name,
                    CreateBy = entity.CreateBy,
                    Creator = entity.CreateBy == null ? string.Empty : entity.Username,
                    Firstname = entity.Firstname,
                    Lastname = entity.Lastname,
                    Username = entity.Username,
                    Password = entity.Password
                }).ToList();
            }
        }
    }
}
