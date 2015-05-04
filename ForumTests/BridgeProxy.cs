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

        public ForumSystem.Forum createForum(string title, List<string> admins)
        {
            if (this.real != null)
            {
                return (real.createForum(title, admins));
            }
            return null;
        }

        public string login(Guest g,string id, string username, string password)
        {
            if (this.real != null)
            {
                return real.login(g,id, username, password);
            }
            return null;
        }

        public SubForum createSubForum(string title, List<string> moderators, string parent, int maxModerators)
        {
            if (this.real != null)
            {
                return (real.createSubForum(title, moderators, parent,maxModerators));
            }
            return null;
        }

        public Member createMember(string username, string password, string email)
        {
            if (this.real != null)
            {
                return real.createMember(username, password, email);
            }
            return null;
        }


        //public void addMemberToSystem(Member member)
        //{
        //    if (this.real != null)
        //    {
        //        real.addMemberToSystem(member);
        //    }
        //}


        public void removeSubForum(string sfName, string forumName)
        {
            if (this.real != null)
            {
                real.removeSubForum(sfName, forumName);
            }
        }


        public void register(Guest g, string username, string password, string email)
        {
            if (this.real != null)
            {
                real.register(g, username, password, email);
            }
        }


        public bool IsSubForumExists(string subForumName, string forumName)
        {
            if (this.real != null)
            {
                return real.IsSubForumExists(subForumName, forumName);
            }
            else return false;
        }


        public void addMemberToSystem(Member member)
        {
            throw new NotImplementedException();
        }
    }
}
