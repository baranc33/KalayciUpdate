using Kalayci.Shared.Entities.Abstract;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Entities.Concrete
{
    public class KalayciUser : IdentityUser, IEntity
    {
  

     
        public string Linkedin { get; set; }
    


        public string PasswordBackUp { get; set; }




        public int personelId{ get; set; } // hangi spool gönderildi
        public Personel personel{ get; set; }


        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual DateTime ModifiedDate { get; set; } = DateTime.Now;
        public virtual bool IsDeleted { get; set; } = false;
        public virtual string CreatedByName { get; set; } = "Admin";
        public virtual string ModifiedByName { get; set; } = "Admin";
        public ICollection<Project> Projects { get; set; }
        public ICollection<Point> Points { get; set; }
        public ICollection<Personel> ManagePersonel { get; set; }
    }
}
