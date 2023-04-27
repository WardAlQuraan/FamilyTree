using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.USER
{
    public class LoginInfo
    {
        [Required]
        public string Email { get; set; }
        [MinLength(8)]
        public string Password { get; set; }

    }
}
