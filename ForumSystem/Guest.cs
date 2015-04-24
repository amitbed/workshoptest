using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
namespace ForumSystem
{
   public class Guest : User
    {
        private ForumSystem forumSystem = ForumSystem.initForumSystem();

        public void register(string username, string password, string email)
        {
            approveEmail();
            forumSystem.addMember(username, password, email);     
        }

        private bool validateUsername(string username)
        {
           return forumSystem.isUsernameExists(username);
        }

        private bool validateEmail(string email)
        {
            return email.Contains("@");   
        }
        
        private bool approveEmail()
        {
            MailMessage meassage = new MailMessage();
            SmtpClient server = new SmtpClient("smtp.gmail.com");
            meassage.From = new MailAddress("forumworkshop152@gmail.com");
            meassage.Subject = "Approve this mail in order to register the forum";
            meassage.Body = "please reply this mail with any content in order to complete the registration";
            server.Port = 587;
            server.Credentials = new System.Net.NetworkCredential("forumworkshop152", "nofarifatdeanamitsagi");
            server.EnableSsl = true;
            server.Send(meassage);
            return true;
        }

        public bool login(string username, string password, ForumSystem forumSystem)
        {
            bool loggedIn = false;
            foreach (Member member in forumSystem.Members)
            {
                if (String.Equals(username, member.username) && String.Equals(password, member.password))
                {
                    Console.WriteLine("Login Successfull.");
                    loggedIn = true;
                    return loggedIn;
                }
                else
                {
                    Console.WriteLine("Login Failed.");
                }
            }
            return loggedIn;
        }
    }
}
