using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_EF.Models;

namespace WebApp_EF.Repository
{
 public   interface IUserModelRepo
    {
        List<UserRegisterDBModel> DisPlayAllUser();

        int InsertUserReg(UserRegisterDBModel registerDBModel);
    }
}
