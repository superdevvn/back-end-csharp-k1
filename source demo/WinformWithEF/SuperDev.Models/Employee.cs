using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace SuperDev.Models
{
    public partial class SuperDevDbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }
    public class Employee
    {
        public int Id { get; set; }

        public int DepartmentId { get; set; }

        public int? SupervisorId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        [Index("IX_Code", IsUnique = true)]
        [MaxLength(50)]
        public string Code { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public double Salary { get; set; }

        public string Sex { get; set; }

        public DateTime Birthdate { get; set; }

        public DateTime StartedDate { get; set; }

        public Employee() { }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        [ForeignKey("SupervisorId")]
        public virtual Employee Supervisor { get; set; }
    }

    public class EmployeeComplex
    {
        public int Id { get; set; }

        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public int? SupervisorId { get; set; }

        public string SupervisorName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public double Salary { get; set; }

        public string Sex { get; set; }

        public DateTime Birthdate { get; set; }

        public DateTime StartedDate { get; set; }
    }
}
