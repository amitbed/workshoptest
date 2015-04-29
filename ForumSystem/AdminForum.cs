using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem
{
    public class AdminForum : Forum
    {
        Forum Parentforum;

        public AdminForum(Forum forum)
        {
            Parentforum = forum;
        }
    }
}
