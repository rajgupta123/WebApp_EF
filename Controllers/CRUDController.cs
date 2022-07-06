using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_EF.Models;

namespace WebApp_EF.Controllers
{
    public class CRUDController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(UserModel userModel,string command)
        {
            if(command=="Insert")
            {

            }
            else if(command=="Update")
            {

            }
            else if(command=="delete")
            {

            }

            return View();
        }
    }
}
