using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem
{
    public class ModeratorSubForum : MemberSubForum
    {
        private MemberSubForum msf;

        public ModeratorSubForum(MemberSubForum msf)
        {
            this.msf = msf;
        }
    }
}
