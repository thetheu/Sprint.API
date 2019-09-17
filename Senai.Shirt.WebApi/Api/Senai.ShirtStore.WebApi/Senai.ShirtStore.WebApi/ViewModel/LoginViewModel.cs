using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.ShirtStore.WebApi.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }
        [StringLength(30, MinimumLength = 4)]
        public string Senha { get; set; }
    }
}
