using Kalayci.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Entities.Concrete
{
    public class User : EntityBase, IEntity
    {
        public string? Name{ get; set; }
        public string? LastName{ get; set; }
        public string? Image{ get; set; }
        public string? Job { get; set; }
        public string? Linkedin { get; set; }
        public string? Facebook { get; set; }
        public string? Instegram { get; set; }
        public string? Phone { get; set; }
        public string? Mail { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public byte Statu{ get; set; }



        public int RoleId { get; set; }
        public Role? Role { get; set; }
        public ICollection<Project>? Projects{ get; set; }
    }
}
