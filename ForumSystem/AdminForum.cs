using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem
{
    public class AdminForum : Forum
    {
        Forum parentforum;
        public int MaxModerators { get; set; }

        public AdminForum(Forum forum)
        {
            parentforum = forum;

        }

        public void setProperties(int moderatorNumber)
        {
            foreach (SubForum s in parentforum.SubForums.Values)
            {
                s.MaxModerators = moderatorNumber;
            }
        }
    }
}
