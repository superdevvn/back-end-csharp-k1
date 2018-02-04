using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User
    {
        public Guid Id { get; set; }

        //public Guid? RoleId { get; set; }

        //public Guid CreatedBy { get; set; }

        [StringLength(50)] //định dạng xem string đc nhập bao nhiêu ký tự :)
        [Index("Ix_Username", 1, IsUnique = true)] //duy nhất
        public string Username { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        //[ForeignKey("RoleId")]
        //public virtual Role Role { get; set; }
        //[ForeignKey("CreatedBy")]
        //public virtual User Creator { get; set; }
    }


    public class UserComplex
    {
        public Guid Id { get; set; }

        public Guid? RoleId { get; set; }

        public Guid CreatedBy { get; set; }

        //duy nhất
        public string Username { get; set; }


        public string Password { get; set; }


        public string FirstName { get; set; }


        public string LastName { get; set; }


        public string Description { get; set; }

        public string Creator { get; set; }

        public string RoleName { get; set; }
    }
}
