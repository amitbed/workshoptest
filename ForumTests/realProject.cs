using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ForumSystem;

namespace ForumTests
{
    public class realProject : BridgeProject
    {
        ForumSystem.ForumSystem system = ForumSystem.ForumSystem.initForumSystem();

        public Forum createForum(string title, List<string> admins)
        {
            Forum f = new Forum(title, admins);
            system.createForum(f);
            return f;
        }

        public Member createMember(string username, string password, string email)
        {
            Guest g = new Guest();
            string memberID = g.register(username, password, email);
            return system.Members[username];
        }

        public void removeSubForum(string sfName, string forumName)
        {
            Forum f = system.searchForum(forumName);
            SubForum sf = f.SearchSubForum(sfName);

            //TODO:
        }

        public string login(Guest g,string id, string username, string password)
        {
            return g.login(username,password);
        }


        public void register(Guest g, string username, string password, string email)
        {
            g.register(username, password, email);
        }


        public bool IsSubForumExists(string subForumName, string forumName)
        {
            Forum forum =  system.Forums[forumName];
            return (forum.SubForums[subForumName] != null);
        }


        public void addMemberToSystem(Member member)
        {
            throw new NotImplementedException();
        }


        public Member getMember(string userName)
        {
            if (system.Members.ContainsKey(userName))
            {
                return system.Members[userName];
            }
            return null;
        }
    }
}