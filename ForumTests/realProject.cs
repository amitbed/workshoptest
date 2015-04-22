using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ForumSystem;

namespace ForumTests
{
    public class realProject : BridgeProject
    {
        ForumSystem.ForumSystem system = ForumSystem.ForumSystem.getInstance();

        public void addNewaddNewForum(Forum forum)
        {
            system.addForum(forum);
        }

        public Forum createForum(int id, string title, List<int> admins)
        {
            return (new Forum(id, title, admins));
        }


        public SubForum createSubForum(int id, string title, List<string> moderators, string parent)
        {
            return new SubForum(id, title, moderators, parent); 
        }

        public void addForumToSystem(Forum forum)
        {
            system.addForum(forum);
        }
    }
}
