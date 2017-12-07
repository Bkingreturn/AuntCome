using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using AuntCome.DataBase;

namespace AuntCome.Models
{
    public class ManageLoginViewModel:IValidatableObject
    {
        [Required]
        [Display(Name = "账号")]

        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]

        public string Password { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            MySqlConnection conn = null;
            conn = new MySqlConnection("Data Source=101.132.148.93;Initial Catalog=auntcoming;User ID=root;Password=wudixiaofendui");
            conn.Open();
            MySqlDataReader dr = null;
            MySqlCommand com1 = new MySqlCommand("SELECT * FROM admin WHERE Username='" + Username + "'", conn);
            dr = com1.ExecuteReader();
            if (dr.Read())
            {
                if (dr["Username"].ToString() == Username && dr["Password"].ToString() != Password)
                {
                    yield return new ValidationResult("密码错误！");
                }
            }
            else
            {
                yield return new ValidationResult("该账号不存在！");
            }
        }
    }
    public class ManageRegisterViewModel:IValidatableObject
    {
        [Required]
        [Display(Name = "账号")]

        public string Username { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "电子邮件")]
        public string Email { get; set; }
        [Required]
        [Display(Name ="手机号")]
        public string Phone { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]

        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Compare("Password", ErrorMessage = "密码和确认密码不匹配。")]
        public string ConfirmPassword { get; set; }
        public IEnumerable<ValidationResult>Validate(ValidationContext validationContext)
        {
            MySqlConnection conn = null;
            conn = new MySqlConnection("Data Source=101.132.148.93;Initial Catalog=auntcoming;User ID=root;Password=wudixiaofendui");
            conn.Open();
            MySqlDataReader dr = null;
            MySqlCommand com1 = new MySqlCommand("SELECT * FROM admin WHERE Username='" + Username + "';SELECT * FROM admin WHERE Email='" + Email + "';SELECT * FROM admin WHERE Phone='" + Phone + "';", conn);
            dr = com1.ExecuteReader();
            if (dr.Read())
            {
                yield return new ValidationResult("该账号已存在！");
            }
            if (dr.NextResult()) {
            if (dr.Read())
            {
                yield return new ValidationResult("该邮箱已被注册！");
            }
            }
            if (dr.NextResult())
            {
                if (dr.Read())
                {
                    yield return new ValidationResult("该手机号已被注册！");
                }
            }
            conn.Close();
        }
    }
    public class ManageForgetPasswordViewModel: IValidatableObject
    {
        [Required]
        [Display(Name ="账号")]
        public string Username { get; set; }
        [Required]
        [Display(Name ="邮箱")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name ="手机号")]
        public string Phone { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            string connectstring = "SELECT * FROM admin WHERE Username='" + Username + "'";
            database db;
            db = new database();
            db.ConnectMySQL();
            db.Find(connectstring);
            if (db.dr.Read())
            {
                if (db.dr["Email"].ToString() != Email) yield return new ValidationResult("邮箱错误！");
                else if (db.dr["Phone"].ToString() != Phone) yield return new ValidationResult("手机号错误！");
            }
        }
    }
    public class ManageResetPasswordViewModel
    {
        [Required]
        [Display(Name = "新密码")]
        public string Password { get; set; }
        [Required]
        [Display(Name ="确认密码")]
        [Compare("Password", ErrorMessage = "密码和确认密码不匹配。")]
        public string ConfirmPassword { get; set; }
    }
}