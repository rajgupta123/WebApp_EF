using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_EF.Models;

namespace WebApp_EF.Helpers
{
    public class ApplicationMapper:Profile
    {
        public ApplicationMapper()
        {
            CreateMap<UserRegisterModel, UserRegisterDBModel>().ReverseMap();
        }
    }
}
