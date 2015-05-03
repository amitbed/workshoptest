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

        public void addSubForum(SubForum subForum)
        {
            if (subForum != null)
            {
                SubForums.Add(subForum.Title, subForum);
                MemberSubForum msf = new MemberSubForum(subForum);
                MemberSubForums.Add(subForum.Title, msf);
                ModeratorSubForums.Add(subForum.Title, new ModeratorSubForum(msf));

                Logger.logDebug(string.Format("The new sub forum: {0} has been created successfully with id {1}", subForum.Title, subForum.ID));
            }
            else
            {
                Logger.logError("Failed to add sub forum. Reason: sub forum is null");
            }

        }

        public void deleteSubForum(string subForumID)
        {
            //TODO: add implementation
        }

        public void upgradeMemberID(string memberID)
        {
            //TODO: add implementation
        }

        public void downgraeMember(string memberID)
        {
            //TODO: add implementation
        }
    }
}
