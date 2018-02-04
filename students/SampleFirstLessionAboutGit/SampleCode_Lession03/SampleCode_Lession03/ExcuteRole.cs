using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCode_Lession03
{
    public class ExcuteRole
    {
        public static void CreateNewRole()
        {
            Role role = new Role();
            Console.Write("Role code : ");
            role.Code = Console.ReadLine();
            Console.Write("Role name : ");
            role.Name = Console.ReadLine();
            RoleRepositoty roleRepositoty = new RoleRepositoty();
            roleRepositoty.Create(role);

        }

        public static void updateRole()
        {
            Role role = new Role();
            Guid id = new Guid("0B78968F-813E-4CA4-B55A-32D0B5F06302");
            RoleRepositoty roleRepositoty = new RoleRepositoty();
            role = roleRepositoty.getById(id);
            Console.WriteLine((String.Format("Currend Code : {0}", role.Code)));
            Console.Write("New Role : ");
            role.Code = Console.ReadLine();
            Console.WriteLine((String.Format("Currend Name : {0}", role.Name)));
            Console.Write("New Name : ");
            role.Name = Console.ReadLine();
            roleRepositoty.updateRole(role);

        }

        public static void deleteRole()
        {
            Guid id = new Guid("2ee3ef14-2984-4159-9da8-15debcbf49d4");
            RoleRepositoty roleRepositoty = new RoleRepositoty();
            roleRepositoty.deleteRole(id);
        }

        public static void getList()
        {
            RoleRepositoty roleRepositoty = new RoleRepositoty();
            List<Role> roles = roleRepositoty.getList();

            foreach(var role in roles)
            {
                Console.WriteLine(String.Format("Code : {0}, Code : {1}, Name : {2}", role.Id, role.Code, role.Name));
            }
        }

    }
}
