using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using Models.Other;

namespace Repositories
{
    public class RoleRepository
    {

        public Role GetById(Guid id)
        {
            using (var context = new SuperDevDbContext())
            {
                return context.Roles.Find(id);
            }
        }

        public Role Create(Role role)
        {
            using (var context = new SuperDevDbContext())
            {
                role.Id = Guid.NewGuid();
                role.CreatedDate = DateTime.Now;
                context.Roles.Add(role);
                context.SaveChanges();
                return context.Roles.Find(role.Id);
            }
        }

        public Role Update(Role role)
        {
            using (var context = new SuperDevDbContext())
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
            using (var context = new SuperDevDbContext())
            {
                var entity = context.Roles.Find(id);
                context.Roles.Remove(entity);
                context.SaveChanges();
            }
        }

        public List<Role> GetList()
        {
            using (var context = new SuperDevDbContext())
            {
                return context.Roles.ToList();
            }
        }
    }
}
