﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Entities.Dto
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Kullanıcı Adı Zorunludur")]
        public string UserName { get; set; } = "";


        [Required(ErrorMessage = "Şifre alanı Zorunludur")]
        [DataType(DataType.Password)]
        [MinLength(4, ErrorMessage = "şifreniz en az 4 karakterli olmalıdır.")]
        public string Password { get; set; } = "";


        public bool RememberMe { get; set; } = false;
    }
}
