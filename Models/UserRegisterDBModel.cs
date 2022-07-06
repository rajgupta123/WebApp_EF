using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApp_EF.Models
{
    public class UserRegisterDBModel
    {
       
        [Key]
        public int UserId { get; set; }
     
        public string UserEmail { get; set; }
        
       
        public string Password { get; set; }
      
       

       
        public long MobileNumber { get; set; }
    }
}
