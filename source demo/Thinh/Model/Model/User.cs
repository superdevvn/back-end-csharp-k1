using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User
    {
        public Guid Id { get; set; }

        public Guid RoleId { get; set; }
        public Guid? CreateBy { get; set; }
        [StringLength(50)]
        [Index("IX_Username", 1, IsUnique = true)]
        public string Username { get; set; }
        [StringLength(50)]//dinh dang kieu nhap duoc bao nhieu ky tu.
        public string Password { get; set; }
        [StringLength(50)]
        public string Firstname { get; set; }
        [StringLength(50)]
        public string Lastname { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        [ForeignKey("RoleId")]//Set key 
        public virtual Role Role { get; set; }
        [ForeignKey("CreateBy")]
        public virtual User Creator { get; set; }
    }
}
