using Models;
using Models.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RoleRepositoty

    {

    public Role getById(Guid id)
        {
            using (var context = new SuperDevDbContext())
            {
                return context.Roles.Find(id);
            }
        }

        public Role Create(Role role)
        {
            using(var context = new SuperDevDbContext()) //nếu không có using thì hết hàm nó tự hủy còn không thì xài hết using thì nó hủy
            {
                role.Id = Guid.NewGuid();
                role.CreatedDate = DateTime.Now;
                context.Roles.Add(role);
                context.SaveChanges();
                return context.Roles.Find(role.Id);

            }
        }

        public Role updateRole(Role role)
        {
            using(var context = new SuperDevDbContext())
            {
                var entity = context.Roles.Find(role.Id);
                entity.Code = role.Code;
                entity.Name = role.Name;
                context.SaveChanges();
                return context.Roles.Find(role.Id);
            }
        }

        public void deleteRole(Guid id)
        {
            using (var context = new SuperDevDbContext())
            {
                var entity = context.Roles.Find(id);
                context.Roles.Remove(entity);
                context.SaveChanges();
            }
        }


        public List<Role> getList()
        {
            using (var context = new SuperDevDbContext()) //nếu không có using thì hết hàm nó tự hủy còn không thì xài hết using thì nó hủy
            {
                return context.Roles.ToList();
            }
        }
    }
}
