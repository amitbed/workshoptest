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

        public void addNewaddNewForum(Forum forum)
        {
            system.addForum(forum);
        }

        public Forum createForum(string title, List<string> admins)
        {
            Forum f = new Forum(title, admins, new System.Text.RegularExpressions.Regex(""));
            system.addForum(f);
            return f;
        }

        public SubForum createSubForum(string title, List<string> moderators, string parent)
        {
            SubForum sb = new SubForum(title, moderators, parent);
            Forum f = system.searchForum(parent);
            if (f != null)
            {
                f.addSubForum(sb);
            }
            else
            {
                f = new Forum(parent, moderators, new System.Text.RegularExpressions.Regex(""));  //(parent, moderators);
                f.addSubForum(sb);
            }
            return sb;
        }

        public Member createMember(string username, string password, string email)
        {
            Guest g = new Guest();
            string memberID = g.register(username, password, email);
            return system.Members[memberID];
        }

        public void removeSubForum(string sfName, string forumName)
        {
            Forum f = system.searchForum(forumName);
            SubForum sf = f.SearchSubForum(sfName);

            //TODO:
        }

        public string login(Guest g,string id, string username, string password)
        {
            return g.login(id,username,password);
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
    }
}
