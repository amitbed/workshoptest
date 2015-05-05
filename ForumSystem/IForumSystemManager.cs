using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem
{
    interface IForumSystemManager
    {
        ForumSystem initForumSystem();
        void createForum(Forum forum);
        string displayForums();
        Forum enterForum(Member member, string forumName);
    }
}
