using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem
{
    public class MemberSubForum : SubForum
    {
        public MemberSubForum() { }
        public MemberSubForum(string title, List<string> moderators, string parent, int maxModerators): base(title, moderators, parent, maxModerators)
        {
            
        }
    }
}
