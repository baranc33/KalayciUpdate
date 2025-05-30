using Kalayci.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Entities.Concrete
{
    public class Personel : EntityBase, IEntity
    {

        public string Name{ get; set; }
        public string LastName{ get; set; }

        public string SgkRegistrationNumber{ get; set; }
        public string TcNumber{ get; set; }
        public DateTime BirthDay{ get; set; }
        public bool Gender{ get; set; }
        public byte OverallScore{ get; set; }
        public byte TechnicalPoint { get; set; }



        public string Phone{ get; set; }
        public string Picture{ get; set; }
        public DateTime WorkStartDate{ get; set; }
        public DateTime WorkFinishDate { get; set; } 
        //public string AutorizedProject { get; set; }


        public int branchId { get; set; }
        public Branch branch { get; set; }
        public KalayciUser User{ get; set; }
        public ICollection<Point> points { get; set; }
        public ICollection<PersonelProject> PersonelProjects { get; set; }

    }
}
