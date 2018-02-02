using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Repositories;

namespace SimpleCodeFirst
{
    public class ExcuteRole
    {
        public static void CreateNewRole()
        {
            try
            {
                Role role = new Role();
                Console.Write("Role code: ");
                role.Code = Console.ReadLine();
                Console.Write("Role name: ");
                role.Name = Console.ReadLine();
                RoleRepository roleRepository = new RoleRepository();
                roleRepository.Create(role);
                Console.WriteLine("*****************************");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void UpdateRole()
        {
            RoleRepository roleRepository = new RoleRepository();
            Guid id = new Guid("05ad8ba2-6ca2-4c77-9190-bfd7cc6e7706");
            Role role = roleRepository.GetById(id);
            Console.WriteLine(string.Format("Current code: {0}", role.Code));
            Console.Write("New code: ");
            role.Code = Console.ReadLine();
            Console.WriteLine(string.Format("Current name: {0}", role.Name));
            Console.Write("New name: ");
            role.Name = Console.ReadLine();
            roleRepository.Update(role);
            Console.WriteLine("*****************************");
        }

        public static void DeleteRole()
        {
            RoleRepository roleRepository = new RoleRepository();
            Guid id = new Guid("05ad8ba2-6ca2-4c77-9190-bfd7cc6e7706");
            roleRepository.Delete(id);
        }

        public static void GetList()
        {
            RoleRepository roleRepository = new RoleRepository();
            List<Role> roles = roleRepository.GetList();
            foreach(var role in roles)
            {
                Console.WriteLine(string.Format("Id: {0}, Code: {1}, Name: {2}", role.Id, role.Code, role.Name));
            }
            Console.WriteLine("*****************************");
        }
    }
}
