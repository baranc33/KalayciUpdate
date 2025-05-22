using Kalayci.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Entities.Concrete
{
    public class Role : EntityBase, IEntity 
    {

        public string Name { get; set; } = "Boş Role Oluşturuldu";
        public string Description { get; set; } = "Default Description";
        public ICollection<User>? Users { get; set; } 
    }
}
