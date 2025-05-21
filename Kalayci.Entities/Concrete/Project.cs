using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Entities.Concrete
{
    public class Project
    {

        public string ProjectName{ get; set; }
        //spoollar projeye dahildir
        public ICollection<SpoolList> spoolLists{ get; set; }

        // 1 adet proje yetkilisi olur ama admin rolüde projeyi değiştirebilir
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
