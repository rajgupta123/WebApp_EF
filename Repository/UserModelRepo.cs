using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_EF.Models;
using WebApp_EF.DataAccessLayer_EF;

namespace WebApp_EF.Repository
{
    public class UserModelRepo : IUserModelRepo
    {
        private readonly DataAccessLayer_LMS dataAccessLayer_LMS;
     
        public UserModelRepo(DataAccessLayer_LMS dataAccessLayer_LMS)
        {
            this.dataAccessLayer_LMS = dataAccessLayer_LMS;
        }
        public List<UserRegisterDBModel> DisPlayAllUser()
        {
            var ar = dataAccessLayer_LMS.UserRegister.ToList();
            return ar;
        }

        public int InsertUserReg(UserRegisterDBModel registerDBModel)
        {
            dataAccessLayer_LMS.Add(registerDBModel);
            dataAccessLayer_LMS.SaveChanges();
            return 1;
        }
    }
}
