using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem
{
    public class Forum
    {
        #region variables
        public string ID { get; set; }
        public string Title { get; set; }
        public Dictionary<string, SubForum> SubForums { get; set; }
        public Dictionary<string, MemberSubForum> MemberSubForums { get; set; }
        public Dictionary<string, ModeratorSubForum> ModeratorSubForums { get; set; }
        public List<string> Admins { get; set; }

        #endregion

        #region Ctor
        public Forum() { }
        public Forum(string title, List<string> admins)
        {
            this.ID = IdGen.generateForumId();
            this.SubForums = new Dictionary<string, SubForum>();
            this.Title = Title;
            this.Admins = admins;
            if ((admins == null) || (String.IsNullOrEmpty(title)))
            {
                if ((String.IsNullOrEmpty(title)) && (!(admins == null)))
                {
                    Logger.logError(string.Format("Failed to create a new forum. Reason: title is empty"));
                }
                if ((!String.IsNullOrEmpty(title)) && ((admins == null)))
                {
                    Logger.logError(string.Format("Failed to create a new forum. Reason: admins is null"));
                }
            }
            else
            {
                Logger.logDebug(string.Format("The new forum: {0} has been created successfully with id {1}", title, ID));
            }
        }
        #endregion

        #region Methods

        //This method displays a forum's sub forums
        public string displaySubforums()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string subForumTitle in SubForums.Keys)
            {
                sb.Append(subForumTitle + "\n");
            }
            return sb.ToString();
        }

        //This method adds a sub-forum to the current forum
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

        public SubForum SearchSubForum(string sfName)
        {
            return SubForums[sfName];
        }

        public SubForum enterSubForum(string subForumName, User user)
        {
            ForumSystem forumSystem = ForumSystem.initForumSystem();
            SubForum subForumToEnter = this.SubForums[subForumName];
            if (subForumToEnter == null)
            {
                Logger.logError(String.Format("Failed to recieve sub forum {0}", subForumName));
                return null;
            }
            else
            {
                if (user.GetType().Name.Equals("Member"))
                {
                    Member newUser = (Member)user;
                    if (subForumToEnter.Moderators.Contains(newUser.ID))
                    {
                        Logger.logDebug(String.Format("{0} enterd to sub forum {1} as moderator", this.ID, subForumName));
                        return ModeratorSubForums[subForumName];
                    }
                    else
                    {
                        Logger.logDebug(String.Format("{0} enterd to sub forum {1} as member", this.ID, subForumName));
                        return MemberSubForums[subForumName];
                    }
                }
                else
                {
                    Logger.logDebug(String.Format("{0} enterd to sub forum {1} as guest", this.ID, subForumName));
                    return subForumToEnter;
                }
            }
        }
    }
        #endregion
}
