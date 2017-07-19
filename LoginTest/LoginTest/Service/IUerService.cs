using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginTest.Models.Domain;

namespace LoginTest.Service
{
    interface IUerService
    {
        IList<User> FindUserByUserName(string userName);
        bool CheckAccountInfo(string userName, string pwd);
        void CreatUser(User user);
        bool SendMail(string to);

    }
}
