using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Shared.Entities.Abstract
{
    public class EntityBase
    {

        public  int Id { get; set; }
        public  DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
        public  string CreatedByName { get; set; } = "System";
        public  string ModifiedByName { get; set; } = "System";
    }
}
