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
            return (new Forum(title, admins));
        }


        public SubForum createSubForum(string title, List<string> moderators, string parent)
        {
            return new SubForum(title, moderators, parent); 
        }

        public void addForumToSystem(Forum forum)
        {
            system.addForum(forum);
        }
    }
}
