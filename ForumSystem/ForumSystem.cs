﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem
{
    public class ForumSystem
    {
        private static ForumSystem forumSystem = null;
        public List<Forum> Forums { get; }
        private List<Member> members;

        //Constructor
        private ForumSystem()
        {
            Logger log = new Logger();
            members = new List<Member>();
            Forums = new List<Forum>();
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
                forums.Add(forum);
                Logger.logDebug(String.Format("A new forum has been added to forum system. ID: {0}, Title: {1}", forum.ID, forum.Title));
            }
        }

        //This method displays all the forums in the system
        public void displayForums()
        {
            foreach (Forum forum in forums)
            {
                Console.WriteLine(forum.Title);
            }
        }

        public List<Member> Members
        {
            get { return this.members; }
        }

        //This method returns all the forums in the system

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
                members.Add(toAdd);
                Logger.logDebug(String.Format("A new member has been added. ID: {0}, username: {1}, password: {2}, email: {3}",toAdd.id,username,password,email));
                return toAdd;
            }
        }

        public bool isUsernameExists(string newUsername)
        {
            foreach (Member m in members)
            {
                if (m.username.Equals(newUsername))
                    return true;
            }
            return false;
        }

        public Forum searchForum(string forumID)
        {
            foreach (Forum f in Forums)
            {
                if (f.ID.Equals(forumID))
                {
                    return f;
                }
            }
            return null;
        }

    }
}
