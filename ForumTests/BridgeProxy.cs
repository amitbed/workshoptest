using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumSystem;

namespace ForumTests
{
    class BridgeProxy : BridgeProject
    {
        private BridgeProject real;

        public BridgeProxy()
        {
            this.real = null;
        }

        public BridgeProject setRealBridge(BridgeProject real)
        {
            this.real = real;
            return this.real;
        }


        public void addNewaddNewForum(ForumSystem.Forum forum)
        {
            if (this.real != null)
            {
                real.addNewaddNewForum(forum);
            }
        }

        public ForumSystem.Forum createForum(int id, string title, List<int> admins)
        {
            if (this.real != null)
            {
                return (real.createForum(id, title, admins));
            }
            return null;
        }


        public SubForum createSubForum(int id, string title, List<string> moderators, string parent)
        {
            if (this.real != null)
            {
                return (real.createSubForum(id, title, moderators, parent));
            }
            return null;
        }

        public void addForumToSystem(Forum forum)
        {
            if (this.real != null)
            {
                real.addForumToSystem(forum);
            }
        }
    }
}
