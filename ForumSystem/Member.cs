using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem
{
    public class Member : User
    {
        public string ID { get; set; }
        public string Username { get; set; }
        private string email;
        public string Password { get; set; }
        private bool isActive;
        private List<string> myFriends;
        private List<string> myThreads;
        private List<string> mySubForums;
        private List<string> myForums;
        //private double seniority;
        private double timeLoggedIn;
        //private int numberOfMessagesLastYear;

        public Member() { }

        public Member(string username, string password, string emailAddress)
        {
            if ((String.IsNullOrEmpty(username)) || (String.IsNullOrEmpty(password)) || (String.IsNullOrEmpty(emailAddress)))
            {
                if (String.IsNullOrEmpty(username))
                {
                    Logger.logError("Failed to create a new member. Reason: username is empty");
                }
                if (String.IsNullOrEmpty(password))
                {
                    Logger.logError("Failed to create a new member. Reason: password is empty");
                }
                if (String.IsNullOrEmpty(emailAddress))
                {
                    Logger.logError("Failed to create a new member. Reason: email is empty");
                }
            }
            else
            {
                this.Username = username;
                this.Password = password;
                this.email = emailAddress;
                this.timeLoggedIn = 0;
                this.ID = IdGen.generateMemberId();
                this.isActive = true;
                this.myForums = new List<string>();
                this.mySubForums = new List<string>();
                this.myThreads = new List<string>();
                this.myFriends = new List<string>();
                Logger.logDebug(String.Format("A new user has been created. ID: {0} username: {1}, password: {2}, email: {3}", ID, Username, Password, emailAddress));
            }
        }

        //This method creates a sub-forum
        public bool createSubForum(string title, string parent, List<string> moderators, int maxModerators)
        {
            ForumSystem forumSystem = ForumSystem.initForumSystem();
            if ((String.IsNullOrEmpty(title)) || (String.IsNullOrEmpty(parent) || (moderators == null)))
            {
                if ((String.IsNullOrEmpty(title)))
                {
                    Logger.logError("Failed to create a new sub-forum. Reason: title is empty");
                }

                if ((String.IsNullOrEmpty(parent)))
                {
                    Logger.logError("Failed to create a new sub-forum. Reason: parent is empty");
                }

                if (moderators == null)
                {
                    Logger.logError("Failed to create a new sub-forum. Reason: moderators is null");
                }

                return false;
            }
            else
            {
                SubForum subForum = new SubForum(title, moderators, parent, maxModerators);
                foreach (Forum forum in forumSystem.Forums.Values)
                {
                    if (string.Equals(forum.Title, parent))
                    {
                        forum.addSubForum(subForum);
                        Logger.logDebug(String.Format("Sub forum has added succesfully. ID: {0}, title: {1}", subForum.ID, subForum.Title));
                        return true;
                    }
                }
                Logger.logError("Failed to add a new subform. Reason: parent can not be found");
                return false;
            }
        }

        //This method shows all discussions of a given sub-forum
        public void viewDiscussions(string subForumName, string parent)
        {
            ForumSystem mainForum = ForumSystem.initForumSystem();
            Forum forum;
            SubForum subForum;
            if (mainForum.Forums.ContainsKey(parent)) //&& 
            {
                forum = mainForum.Forums[parent];

                if (forum.SubForums.ContainsKey(subForumName))
                {
                    subForum = forum.SubForums[subForumName];
                    subForum.displayThreads();
                }
            }
        }

        //This method displays messages of a thread
        public void viewMessages(string threadId, string subForumName, string parent)
        {
            ForumSystem mainForum = ForumSystem.initForumSystem();
            if (mainForum.Forums.ContainsKey(parent))
            {
                Forum forum = mainForum.Forums[parent];
                if (forum.SubForums.ContainsKey(subForumName))
                {
                    SubForum subForum = forum.SubForums[subForumName];
                    Thread thread = subForum.Threads[threadId];

                    thread.displayMessages();
                }
            }
        }

        //This method displays a message's replies
        public string displayReplies(string forumName, string subForumName, string discussionTitle, int messageId)
        {
            StringBuilder sb = new StringBuilder();
            ForumSystem mainForum = ForumSystem.initForumSystem();

            if (mainForum.Forums.ContainsKey(forumName))
            {
                Forum forum = mainForum.Forums[forumName];
                if (forum.SubForums.ContainsKey(subForumName))
                {
                    SubForum subForum = forum.SubForums[subForumName];
                    if (subForum.Threads.ContainsKey(discussionTitle))
                    {
                        Thread thread = subForum.Threads[discussionTitle];
                        foreach (Message message in thread.Messages)
                        {
                            if (messageId.Equals(message.ID))
                            {
                                foreach (Message reply in message.Replies)
                                {
                                    sb.Append(reply.displayMessage() + "\n");
                                }
                            }
                        }
                        return sb.ToString();
                    }
                }
            }
            return string.Empty;
        }

        public Forum enterForum(string forumName)
        {
            ForumSystem forumSystem = ForumSystem.initForumSystem();

            if (forumSystem.Forums.ContainsKey(forumName))
            {
                Forum forumToEnter = forumSystem.Forums[forumName];
                if (forumToEnter == null)
                {
                    Logger.logError(String.Format("Failed to recieve forum {0}", forumName));
                    return null;
                }
                else
                {
                    if (myForums.Contains(forumToEnter.ID))
                    {
                        Logger.logDebug(String.Format("{0} enterd to forum {1} as Admin", this.ID, forumName));
                        return forumSystem.AdminsForums[forumName];
                    }
                    else
                    {
                        Logger.logDebug(String.Format("{0} enterd to forum {1} as guest", this.ID, forumName));
                        return forumToEnter;
                    }
                }
            }
            else return null;
        }
    }
}
