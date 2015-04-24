﻿using System;
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
            foreach (Member member in forumSystem.Members)
            {
                if (String.Equals(username, member.username) && String.Equals(password, member.password))
                {
                    Logger.logDebug(String.Format("Member: ID:{0} usernamer:{1} has logged in",member.id,member.username));
                    return true;
                }
                else
                {
                    Logger.logDebug(String.Format("Username: {0}, password{1} failed to log in. Reason: member not found"));
                    return false;
                }
            }
            return false;
        }
    }
}
