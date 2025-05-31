using Kalayci.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Entities.Concrete
{
    public class EmployeeExit : EntityBase, IEntity
    {
        public int PersonelId { get; set; }
        public Personel Personel { get; set; }

        public DateTime StartWorkTime { get; set; }
        public DateTime FinishWorkTime { get; set; }

        public byte PersonelNoteAverage { get; set; }

      


    }
}
