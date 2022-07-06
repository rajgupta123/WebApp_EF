using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApp_EF.Models
{
    public class ManagerModel
    {
        [Key]
        public int MId { get; set; }

        public string MName { get; set; }
        public string MCity { get; set; }
        public long M_Mobile_Number { get; set; }
    }
}
