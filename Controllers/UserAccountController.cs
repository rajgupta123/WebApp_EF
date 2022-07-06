using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_EF.DataAccessLayer_EF;
using WebApp_EF.Models;

namespace WebApp_EF.Controllers
{
    public class UserAccountController : Controller
    {
        DataAccessLayer_LMS _DataAccessLayer;
        private readonly IMapper mapper;

        public UserAccountController(DataAccessLayer_LMS DataAccessLayer,IMapper mapper)
        {
            _DataAccessLayer = DataAccessLayer;
            this.mapper = mapper;
        }
        public IActionResult UserRegistration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UserRegistration(UserRegisterModel userRegisterModel )
        {
            /*
            UserRegisterDBModel obj = new UserRegisterDBModel();
            obj.UserEmail = userRegisterModel.UserEmail;
            obj.Password = userRegisterModel.Password;
            obj.MobileNumber = userRegisterModel.MobileNumber;
            _DataAccessLayer.UserRegister.Add(obj);
            _DataAccessLayer.SaveChanges();
            ViewBag.msg = "UserRegistration Done";
           
            */
            return View();
        }
        public IActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UserLogin(UserRegisterModel userRegisterModel)
        {
            /*
            var ar = _DataAccessLayer.UserRegister.Where(x => x.UserEmail == userRegisterModel.UserEmail && x.Password == userRegisterModel.Password).FirstOrDefault();
            if(ar!=null)
            {
                HttpContext.Session.SetString("Username", ar.UserEmail);
                return RedirectToAction("DashBoard");
            }
            */
            return View();

        }
        public IActionResult DashBoard()
        {
            if (HttpContext.Session.GetString("Username")!=null)
            {
                ViewBag.user = HttpContext.Session.GetString("Username");

            }
            else
            {
                return RedirectToAction("UserLogin");
            }
            return View();
        }
        public IActionResult DisplayUser()
        {
            /*
            List<UserRegisterModel> lst = new List<UserRegisterModel>();
            var ar = _DataAccessLayer.UserRegister.ToList();
            foreach(var i in ar)
            {
                lst.Add(new UserRegisterModel { UserId = i.UserId, UserEmail = i.UserEmail, MobileNumber = i.MobileNumber });
            }
            return View(lst.ToList());
            */
            //AutoMapper

            var ar = _DataAccessLayer.UserRegister.ToList();
           var w= mapper.Map<List<UserRegisterModel>>(ar);
         return   View(w);


        }
        public IActionResult Details(int id)
        {
            var ar = _DataAccessLayer.UserRegister.Where(x => x.UserId == id).FirstOrDefault();
            var w = mapper.Map<UserRegisterModel>(ar);
            return View(w);

        }
        public IActionResult Search(int id)
        {
            var ar = _DataAccessLayer.UserRegister.Where(x => x.UserId == id).FirstOrDefault();
            var w = mapper.Map<UserRegisterModel>(ar);
            return View(w);

        }
    }
}
