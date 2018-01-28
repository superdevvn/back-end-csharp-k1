using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Other;

namespace Repositories
{
    public class UserRepository
    {
        public List<UserComplex> GetList()
        {
            using (var context = new SuperDevDbContext())
            {
                return context.Users.Select(entity => new UserComplex
                {
                    Id = entity.Id,
                    RoleId = entity.RoleId,
                    RoleName = entity.Role.Name,
                    CreatedBy = entity.CreatedBy,
                    CreatorName = entity.CreatedBy == null ? string.Empty : entity.Creator.Username,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    Username = entity.Username,
                    Password = entity.Password,
                    Description = entity.Description
                }).ToList();
            }
        }
    }
}
