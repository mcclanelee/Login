using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginTest.Models.Domain
{
    public class User
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Pwd { get; set; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Gender { set; get; }
        public string Email { set; get; }

        
    }
}