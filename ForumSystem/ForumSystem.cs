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
        private List<Forum> forums;
        private List<Member> members;

        //Constructor
        private ForumSystem()
        {
            members = new List<Member>();
            forums = new List<Forum>();
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
            forums.Add(forum);
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
        public List<Forum> getForums()
        {
            return forums;
        }

        internal void addMember(string username, string password, string email)
        {
            members.Add(new Member(username, password, email));
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

    }
}
