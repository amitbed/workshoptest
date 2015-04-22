using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public bool validateUsername(string username)
        {
           return forumSystem.isUsernameExists(username);
        }

        public bool validateEmail(string email)
        {
            return email.Contains("@");   
        }
        
        private void approveEmail()
        {
            //send and receive approve
        }

        public bool login(string username, string password, ForumSystem forumSystem)
        {
            bool loggedIn = false;
            foreach (Member member in forumSystem.members)
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
