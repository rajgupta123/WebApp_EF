using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_EF.Models
{
    public class UserModel
    {
        public int Id { get; set; }//it will create pk with identity
        public string Name { get; set; }
        public string City { get; set; }
        public long Mobile_Number { get; set; }
    }
}
