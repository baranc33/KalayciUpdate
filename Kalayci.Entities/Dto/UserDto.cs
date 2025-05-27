using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Entities.Dto
{
    public class UserDto
    {
        public string Id{ get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }

        public string Linkedin { get; set; }


        public string Phone { get; set; }
        public string Mail { get; set; }

        public string PasswordBackUp { get; set; }
    }
}
