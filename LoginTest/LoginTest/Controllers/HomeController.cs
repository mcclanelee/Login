using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginTest.Service;
using LoginTest.Models.Domain;
using System.Net.Mail;

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
            //var account = Request["Account"];
            //var pwd = Request["Password"];
            //User user = new User();
            //user.UserName = "mcclane";
            //user.Pwd = "123";
            //new UserService().CreatUser(user);
            return View();
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
            return Content("ok");
        }
    }
}