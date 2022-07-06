using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_EF.DataAccessLayer_EF;
using WebApp_EF.Models;

namespace WebApp_EF.Controllers
{
    public class LMSUsersController : Controller
    {
        DataAccessLayer_LMS _dataAccessLayer_LMS;


        public LMSUsersController(DataAccessLayer_LMS dataAccessLayer_LMS)
        {
            _dataAccessLayer_LMS = dataAccessLayer_LMS;
        }
        [Route("ShowAllUsers")]
        public IActionResult Index()
        {
            var ar = _dataAccessLayer_LMS.Users.OrderBy(x => x.Name);

            return View(ar);
        }
        public IActionResult SearchById(int id)
        {
            var ar = _dataAccessLayer_LMS.Users.Where(x => x.Id == id).FirstOrDefault();
            return View(ar);
        }
        public IActionResult Edit(int id)
        {
            var ar = _dataAccessLayer_LMS.Users.Where(x => x.Id == id).FirstOrDefault();
            return View(ar);
        }
        [HttpPost]
        public IActionResult Edit(UserModel userModel)
        {
            var ar = _dataAccessLayer_LMS.Users.Where(x => x.Id == userModel.Id).FirstOrDefault();
            if (ar != null)
            {
                ar.Name = userModel.Name;
                ar.City = userModel.City;
                ar.Mobile_Number = userModel.Mobile_Number;
                _dataAccessLayer_LMS.SaveChanges();//save the data in database 
                return RedirectToAction("Index");

            }
            return View(ar);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(UserModel userModel)
        {
            _dataAccessLayer_LMS.Users.Add(new UserModel { Name = userModel.Name, City = userModel.City, Mobile_Number = userModel.Mobile_Number });
            _dataAccessLayer_LMS.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                var ar = _dataAccessLayer_LMS.Users.Where(x => x.Id == id).FirstOrDefault();
                return View(ar);
            }
            else
            {
                ViewBag.msg = "Data Not Found";
            }
            return View();
        }
        [HttpPost]
        public IActionResult Delete(UserModel user)
        {
            var ar = _dataAccessLayer_LMS.Users.Where(x => x.Id == user.Id).FirstOrDefault();
            if (ar != null)
            {
                _dataAccessLayer_LMS.Remove(ar);
                _dataAccessLayer_LMS.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}







