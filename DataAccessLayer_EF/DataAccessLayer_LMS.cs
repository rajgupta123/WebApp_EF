using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_EF.Models;
//ORM

namespace WebApp_EF.DataAccessLayer_EF
{
    public class DataAccessLayer_LMS:DbContext
    {
        public DataAccessLayer_LMS(DbContextOptions<DataAccessLayer_LMS>options):base(options)
        {

        }

        public DbSet<UserModel> Users { get; set; }//table name Users
        public DbSet<ManagerModel> Managers { get; set; }//table Managers
        public DbSet<UserRegisterDBModel> UserRegister { get; set; }
    }
}
