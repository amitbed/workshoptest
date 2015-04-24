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
            Forum f = new Forum(title, admins);
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
                f = new Forum(parent, moderators);
                f.addSubForum(sb);
            }
            return sb;

        }

        public Member createMember(string username, string password, string email)
        {
            Guest g = new Guest();
            g.register(username, password, email);
            return new Member(username, password, email);
        }

        public void removeSubForum(string sfName, string forumName)
        {
            Forum f = system.searchForum(forumName);
            SubForum sf = f.SearchSubForum(sfName);

            //TODO:
        }


        public void register(Guest g, string username, string password, string email)
        {
            g.register(username, password, email);
        }
    }
}
