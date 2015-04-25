using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem
{
    public class ForumSystem
    {
        private static ForumSystem forumSystem = null;
        public Dictionary<string, Forum> Forums { get; set; }
        public Dictionary<string, Forum> AdminsForums { get; set; }
        public List<Member> Members { get; set; }

        //Constructor
        private ForumSystem()
        {
            Logger log = new Logger();
            Members = new List<Member>();
            Forums = new Dictionary<string, Forum>();
            AdminsForums = new Dictionary<string, Forum>();
            Logger.logDebug(string.Format("A new forum system has been created"));
        }

        //Methods
        public static ForumSystem initForumSystem()
        {
            if (forumSystem == null)
            {
                forumSystem = new ForumSystem();
            }
            return forumSystem;
        }

        //This method adds a forum to the main forum system
        public void addForum(Forum forum)
        {
            if (forum == null)
            {
                Logger.logError("Failed to add a new forum. Reason: forum is null");
            }
            else
            {                
                Forums.Add(forum.Title, forum);
                AdminsForums.Add(forum.Title, new AdminForum(forum));
                Logger.logDebug(String.Format("A new forum has been added to forum system. ID: {0}, Title: {1}", forum.ID, forum.Title));
            }
        }

        //This method displays all the forums in the system
        public string displayForums()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string forumName in Forums.Keys)
            {
                sb.Append(forumName + "\n");
            }
            return sb.ToString();
        }

        public Member addMember(string username, string password, string email)
        {
            if ((String.IsNullOrEmpty(username)) || (String.IsNullOrEmpty(password)) || (String.IsNullOrEmpty(email)))
            {
                if (String.IsNullOrEmpty(username))
                {
                    Logger.logError("Filed to add a new member. Reason: username is null");
                }
                if (String.IsNullOrEmpty(password))
                {
                    Logger.logError("Filed to add a new member. Reason: password is null");
                }
                if (String.IsNullOrEmpty(email))
                {
                    Logger.logError("Filed to add a new member. Reason: email is null");
                }
                return null;
            }
            else
            {   
                Member toAdd=new Member(username, password, email);
                Members.Add(toAdd);
                Logger.logDebug(String.Format("A new member has been added. ID: {0}, username: {1}, password: {2}, email: {3}",toAdd.ID,username,password,email));
                return toAdd;
            }
        }

        public bool isUsernameExists(string newUsername)
        {
            foreach (Member m in Members)
            {
                if (m.Username.Equals(newUsername))
                    return true;
            }
            return false;
        }

        public Forum searchForum(string forumName)
        {
            //string forumID = getForumIdByName(forumName);
            return (Forums[forumName]);
        }

        //public string getForumIdByName(string forumName)
        //{
        //    foreach (Forum f in Forums.Values)
        //    {
        //        if (f.Title.Equals(forumName))
        //        {
        //            return f.ID;
        //        }
        //    }
        //    return string.Empty;
        //}
    }
}
