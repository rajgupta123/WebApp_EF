using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_EF.Repository;
using AutoMapper;
using WebApp_EF.Models;

namespace WebApp_EF.Controllers
{
    public class MyUser : Controller
    {
        private readonly IUserModelRepo userModelRepo;
        private readonly IMapper mapper;

        public MyUser(IUserModelRepo userModelRepo,IMapper mapper)
        {
            this.userModelRepo = userModelRepo;
            this.mapper = mapper;
        }
        public IActionResult ShowAppUsers()
        {
         var dbdata=   userModelRepo.DisPlayAllUser();
            var w = mapper.Map<List< UserRegisterModel>>(dbdata);

            return View(w);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create( UserRegisterModel userRegister)
        {
            var w = mapper.Map<UserRegisterDBModel>(userRegister);
            int rows = userModelRepo.InsertUserReg(w);
            if(rows>0)
            {
                return RedirectToAction("ShowAppUsers");
            }
            return View();
        }
    }
}
