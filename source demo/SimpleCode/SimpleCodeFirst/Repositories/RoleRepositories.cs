using Models;
using Models.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RoleRepositories
    {
        public Role GetById(Guid id)
        {
            using (var context = new SuperDBContext())
            {
                return context.Roles.Find(id);
            }
        }
        public Role Create(Role role)
        {
            using(var context = new SuperDBContext())
            {
                role.Id = Guid.NewGuid();
                role.CreatedDate = DateTime.Now;
                context.Roles.Add(role);
                context.SaveChanges();
                return context.Roles.Find(role.Id);
            }
        }
        public List<Role> GetList()
        {
            using (var context = new SuperDBContext())
            {
                return context.Roles.ToList();
            }
        }
        public Role Update(Role role)
        {
            using (var context = new SuperDBContext())
            {
                var entity = context.Roles.Find(role.Id);
                entity.Code = role.Code;
                entity.Name = role.Name;
                context.SaveChanges();
                return context.Roles.Find(role.Id);
            }
        }
        public void Delete(Guid id)
        {
            using (var context = new SuperDBContext())
            {
                var entity = context.Roles.Find(id);
                context.Roles.Remove(entity);
                context.SaveChanges();
            }
        }
    }
}
