using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApp_EF.Models
{
    public class UserRegisterModel
    {
      
        public int UserId { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string  UserEmail{ get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public long MobileNumber { get; set; }

    }
}
