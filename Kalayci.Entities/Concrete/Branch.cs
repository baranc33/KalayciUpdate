using Kalayci.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Entities.Concrete
{
    public class Branch : EntityBase, IEntity
    {
        public string BranchName { get; set; } = "Bilgi işlem";
        public string BranchDetay { get; set; } = "Detay Verisi";

        public ICollection<Personel> Personels { get; set; } 
        public ICollection<KalayciUser> KalayciUsers{ get; set; } 
    }
}
