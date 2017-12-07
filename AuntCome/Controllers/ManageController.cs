using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuntCome.Models;
using AuntCome.DataBase;
using MySql.Data.MySqlClient;
using System.Web.Security;

namespace AuntCome.Controllers
{
    
    public class ManageController : Controller
    {
       public static string Username;
        public ActionResult Login()
        {
            return View();
        }
        // GET: Manage
        [HttpPost]
        public ActionResult Login(ManageLoginViewModel model)
        {
            if (ModelState.IsValid) {
                database db=new database();
                string connectstring = "SELECT * FROM admin WHERE Username='" + model.Username + "'";
                db.ConnectMySQL();
                db.Find(connectstring); 
            if (db.dr.Read())
            {
                if (db.dr["Username"].ToString() == model.Username && db.dr["Password"].ToString() == model.Password)
                db.CloseMySQL();
                return RedirectToAction("Index", "Home");
            }
               
            }
            return View();
        }
       public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(ManageRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                string connectstring = "INSERT INTO admin (Username,Email,Phone,Password) VALUES('" + model.Username + "','" + model.Email + "','" + model.Phone + "','" + model.Password + "')";
                database db;
                db = new database();
                db.ConnectMySQL();
                db.Insert(connectstring);
                db.CloseMySQL();
                return RedirectToAction("Login");
            }
            return View();
        }
        public ActionResult ForgetPassword()
        {
            return View();
        }
       [HttpPost]
        public ActionResult ForgetPassword(ManageForgetPasswordViewModel model)
        {
            Username = model.Username;
            if (ModelState.IsValid)
            { 
                string connectstring = "SELECT * FROM admin WHERE Username='" + model.Username + "'";
                database db;
                db = new database();
                db.ConnectMySQL();
                db.Find(connectstring);
                if (db.dr.Read())
                {
                    if (db.dr["Username"].ToString() == model.Username && db.dr["Email"].ToString() == model.Email && db.dr["Phone"].ToString() == model.Phone) 
                        db.CloseMySQL();
                    return RedirectToAction("ResetPassword");
                }
            }
            return View();
        }
        public ActionResult ResetPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ResetPassword(ManageResetPasswordViewModel model)
        { 

            if (ModelState.IsValid)
            {
                string connectstring = "UPDATE admin SET Password='"+model.Password+"' WHERE Username='"+Username+"'";
                database db;
                db = new database();
                db.ConnectMySQL();
                db.Update(connectstring);
                db.CloseMySQL();
                return RedirectToAction("Login");
            }
            return View();
        }
    }
}