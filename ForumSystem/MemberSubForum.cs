using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem
{
    public class MemberSubForum : SubForum
    {
        private SubForum subForum;
        public MemberSubForum() { }
        public MemberSubForum(SubForum subForum)
        {
            this.subForum = subForum;
        }
    }
}
