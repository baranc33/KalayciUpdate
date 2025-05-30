using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Entities.Dto
{
    public class ShipYardDto
    {

        [Required(ErrorMessage = "Tersane Adı Zorunludur")]
        [MinLength(10, ErrorMessage = "Tersane Adı en az 10 karakterli olmalıdır.")]
        public string ShipYardName { get; set; } 

    }
}
