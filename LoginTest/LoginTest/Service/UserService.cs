using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LoginTest.Models.DAO;
using LoginTest.Models.Domain;

namespace LoginTest.Service
{
    public class UserService:IUerService
    {
        public IList<User> FindUserByUserName(string username)
        {
            return new UserDAO().FindUserByUserName(username);
        }
        public bool CheckAccountInfo(string userName,string pwd)
        {
            IList<User> user = new UserDAO().FindAccountInfo(userName, pwd);
            return user.Count() == 0 ? false : true;
        }

        public void CreatUser(User user)
        {
            new UserDAO().SaveUser(user);
        }
    }
}