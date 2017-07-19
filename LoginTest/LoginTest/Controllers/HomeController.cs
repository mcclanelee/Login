using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginTest.Service;
using LoginTest.Models.Domain;
using System.Net.Mail;
using System.Net;

namespace LoginTest.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CheckInfo()
        {
            var account = Request["username"];
            var pwd = Request["password"];
            bool isExist = false;
            isExist = new UserService().CheckAccountInfo(account,pwd);
            if (isExist)
                return Content("ok");
            else
                return Content("none");
        }

        public ActionResult CreatAccount()
        {            
            return View();
        }

        public ActionResult CreatNewUser()
        {
            var firstName = Request["firstname"];
            var lastName = Request["lastname"];
            var userName = Request["username"];
            var pwd = Request["password"];
            var email = Request["email"];
            var gender = Request["gender"];
            User user = new User();
            user.FirstName = firstName;
            user.LastName = lastName;
            user.UserName = userName;
            user.Pwd = pwd;
            user.Email = email;
            user.Gender = gender;
            new UserService().CreatUser(user);
            return Content("插入成功！");
        }

        public ActionResult FindPassword()
        {
            var userName = Request["userName"];
            IList<User>  userList = new UserService().FindUserByUserName(userName);
            return userList.Count == 0 ? Content("User " + userName + "is not in our system") : Content("");
        }

        public ActionResult ForgetPwd()
        {
            return View();
        }

        public ActionResult SendMail()
        {
            var email = Request["email"];
            
            return new UserService().SendMail(email) == true ? Content("ok"): Content("邮件发送出错，请确认邮箱正确！");
        }
    }
}