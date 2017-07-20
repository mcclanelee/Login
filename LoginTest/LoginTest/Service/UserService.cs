using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LoginTest.Models.DAO;
using LoginTest.Models.Domain;
using System.Net;
using System.Net.Mail;

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

        public bool CreatUser(User user)
        {
            return new UserDAO().SaveUser(user);
        }

        public bool SendMail(string to)
        {
            //1.check for email

            //2.if exists then do follows
            System.Net.Mail.SmtpClient client = new SmtpClient("smtp.163.com");
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("mcclanelee@163.com", "lihuilr");
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            MailAddress addressFrom = new MailAddress("mcclanelee@163.com", "我");
            MailAddress addressTo = new MailAddress("usst_mcclane@163.com");

            System.Net.Mail.MailMessage message = new MailMessage(addressFrom, addressTo);
            message.Subject = "主题";
            message.Body = "正文";
            message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
            //message.Attachments.Add(new Attachment(@"c:\1.txt"));
            message.Sender = new MailAddress("mcclanelee@163.com");
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = false;
            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            return true;
        }
    }
}