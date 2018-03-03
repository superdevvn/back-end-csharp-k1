using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperDev.Models;

namespace SuperDev.Repositories
{
    public class EmployeeRepository
    {
        public List<EmployeeComplex> GetList()
        {
            using (var context = new SuperDevDbContext())
            {
                return context.Employees.Select(e => new EmployeeComplex
                {
                    Id = e.Id,
                    DepartmentId = e.DepartmentId,
                    DepartmentName = e.Department.Name,
                    SupervisorId = e.SupervisorId,
                    SupervisorName = e.SupervisorId == null ? string.Empty:e.Supervisor.Name,
                    Code = e.Code,
                    Name = e.Name,
                    Username = e.Username,
                    Password = e.Password,
                    Address = e.Address,
                    Birthdate = e.Birthdate,
                    Salary = e.Salary,
                    Sex = e.Sex,
                    StartedDate = e.StartedDate
                }).ToList();
            }
        }
    }
}
