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
    public class KalayciUser : IdentityUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public string Job { get; set; }
        public string Linkedin { get; set; }
    

        public string Phone { get; set; }
        public string Mail { get; set; }

        public string? PasswordBackUp { get; set; }



        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual DateTime ModifiedDate { get; set; } = DateTime.Now;
        public virtual bool IsDeleted { get; set; } = false;
        public virtual string CreatedByName { get; set; } = "Admin";
        public virtual string ModifiedByName { get; set; } = "Admin";
        public ICollection<Project> Projects { get; set; }
        public ICollection<Point> Points { get; set; }
    }
}
