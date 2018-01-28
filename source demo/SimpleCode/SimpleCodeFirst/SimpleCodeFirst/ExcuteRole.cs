using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCodeFirst
{
    public class ExcuteRole
    {
        public static void CreateNewRole()
        {
            Role role = new Role();
            Console.Write("Role Code : ");
            role.Code = Console.ReadLine();
            Console.Write("Role Name : ");
            role.Name = Console.ReadLine();
            RoleRepositories roleRepository = new RoleRepositories();
            roleRepository.Create(role);
            Console.WriteLine("************************************");
        }
        public static void GetList()
        {
            RoleRepositories roleRepository = new RoleRepositories();
            List<Role> roles = roleRepository.GetList();
            foreach(var role in roles){
                Console.WriteLine(string.Format("Id: {0}, Code: {1}, Name: {2}", role.Id, role.Code, role.Name));
            }
            Console.WriteLine("************************************");
        }
        public static void UpdateRole()
        {
            RoleRepositories roleRepository = new RoleRepositories();
            Guid id = new Guid("aa09d45e-554d-48e2-9c8b-2d98c0e6033f");
            Role role = roleRepository.GetById(id);
            Console.WriteLine(string.Format("Current code: {0}", role.Code));
            Console.Write("New code: ");
            role.Code = Console.ReadLine();
            Console.WriteLine(string.Format("Current name: {0}", role.Name));
            Console.Write("New name: ");
            role.Name = Console.ReadLine();
            roleRepository.Update(role);
            Console.WriteLine("************************************");
        }
        public static void DeleteRole()
        {
            RoleRepositories roleRepository = new RoleRepositories();
            Guid id = new Guid("aa09d45e-554d-48e2-9c8b-2d98c0e6033f");
            roleRepository.Delete(id);
        }
    }
}
