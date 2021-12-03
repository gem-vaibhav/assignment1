using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using assaignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace assaignment.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult RegisterView()
        {
            Models.RegisterationRecord User_entry = new Models.RegisterationRecord();
            return View(User_entry);
        }

        public ActionResult Details(int ID)
        {   Models.AllUsers Users = DataLayer.Database.DetailDB(ID);
            return View(Users);
        }
        
        
        public ActionResult Edit(int ID)
        {
            Models.AllUsers User = DataLayer.Database.DetailDB(ID);
            //DataLayer.Database.Editrecord(User);
            return View(User);
        }
        [HttpPost]
        public ActionResult Edit(Models.AllUsers user)
        {
            DataLayer.Database.Editrecord(user);
            return View(user);
        }
        /// <summary>
        /// Action method for validating input fields and string them into db
        /// </summary>
        /// <param name="details">1.details.First_Name 2.details.Last_Name 3.details.UserGender 4.details.Email_Address 5.details.DateOfBirth</param>
        /// <returns>returns verificationview if validation passed otherwise retturn same page </returns>
        [HttpPost]
        public ActionResult RegisterView(Models.RegisterationRecord details)
        {
            if (new Regex(@"[0-9]").IsMatch(details.First_Name))
            {
                ModelState.AddModelError("First_name", "Please enter valid first name");
            }
            if (new Regex(@"[0-9]").IsMatch(details.Last_Name))
            {
                ModelState.AddModelError("Last_name", "Please enter valid last name");
            }
            if (ModelState.IsValid)
            {
                bool is_inserted;

                DataLayer.Database.RegisterDB(details, out is_inserted);
                if (is_inserted)
                {
                    return RedirectToAction("VerificationView", "Home");
                }
            }
            return View(details);
        }

        public ActionResult VerificationView()
        {
            return View();
        }


        /// <summary>
        ///Action method for validating the passwords in registration process
        /// </summary>
        /// <param name="details">properties=>1.details.Password  2.details.ConfirmPassword</param>
        /// <returns>Login view if validation is passed otherwise returns the same page </returns>
        [HttpPost]
        public ActionResult VerificationView(Models.PasswordVerification details)
        {
            if (details.Password.Length < 8 || details.ConfirmPassword.Length<8)
            {
                ViewBag.Message = "Please enter  password of minimum length 8";
                return View(details);
            }
            
            if (details.Password != details.ConfirmPassword)
            {

                ViewBag.Message = "Passwords do not match";
                return View(details);
            }
            if (ModelState.IsValid)
            {
                DataLayer.Database.PasswordDB(details);
                return RedirectToAction("Index", "Home");
            }
            return View(details);
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Models.LoginRecords data)
        {
            if (ModelState.IsValid)
            {
                if (DataLayer.Database.LoginDB(data))
                {
                    ViewBag.logged_in = true;
                       return RedirectToAction("Menu", "Home"); }

                else
                {
                    if (!string.IsNullOrEmpty(data.Name) && !string.IsNullOrEmpty(data.Password))
                        ViewBag.Message = "Either username or password is incorrect";
                }
            }
            return View(data);
        }

        public ActionResult Menu()
        {
            List<Models.AllUsers> Users= DataLayer.Database.GetUsers();
;            return View(Users);
        }
        
        public ActionResult ForgotPassword()
        {
            return View();
        }
        
        public ActionResult Privacy(Models.LoginRecords userdetail)
        {  if (ViewBag.logged_in==null || ViewBag.logged_in==false)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
        
        [HttpPost]
        public ActionResult ForgotPassword(Models.FindUser details)
        {
            
            if( details.New_Password.Length<8)
            {
                ModelState.AddModelError("New_Password", "Password is too small");
            }
            if (details.Confirm_New_Password.Length<8)
            {
                ModelState.AddModelError("Confirm_New_Password", "Password is too small");
            }
            if (details.New_Password!=details.Confirm_New_Password)
            {
                ViewBag.Message = "Passwords do not match";
                //ModelState.AddModelError("", "Passwords do not match");
            }
            if (ModelState.IsValid)
            {  if (DataLayer.Database.ChangePasswordDB(details))
                    return RedirectToAction("Index", "Home");
                else
                    ViewBag.Message = "User not registered";
            }
            return View(details);
        }

    }
}
