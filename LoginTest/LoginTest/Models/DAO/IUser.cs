using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginTest.Models.Domain;

namespace LoginTest.Models.DAO
{
    interface IUser
    {
       IList<User> FindUserByUserName(string userName);
       IList<User> FindAccountInfo(string userName, string pwd);
       bool SaveUser(User user);
    }
}
