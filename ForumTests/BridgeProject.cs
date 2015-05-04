using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumSystem;
namespace ForumTests
{
    interface BridgeProject
    {
        Forum createForum(string title, List<string> admins);
     //   SubForum createSubForum(string title, List<string> moderators, string parent, int maxModerators);
        Member createMember(string username, string password, string email);
        void register(Guest g, string username, string password, string email);
        void removeSubForum(string sfName, string forumName);
        bool IsSubForumExists(string subForumName, string forumName);
        string login(Guest g,string id, string username, string password);
        void addMemberToSystem(Member member);
    }
}