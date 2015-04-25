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
        public bool createSubForum(string title, string parent, List<string> moderators)
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
                SubForum subForum = new SubForum(title, moderators, parent);
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

            Forum forum = mainForum.Forums[parent];
            SubForum subForum = forum.SubForums[subForumName];

            subForum.displayThreads();
        }

        //This method displays messages of a thread
        public void viewMessages(string threadId, string subForumName, string parent)
        {
            ForumSystem mainForum = ForumSystem.initForumSystem();
            Forum forum = mainForum.Forums[parent];
            SubForum subForum = forum.SubForums[subForumName];
            Thread thread = subForum.Threads[threadId];

            thread.displayMessages();
        }

        //This method displays a message's replies
        public string displayReplies(string forumName, string subForumName, string discussionTitle, int messageId)
        {
            StringBuilder sb = new StringBuilder();
            ForumSystem mainForum = ForumSystem.initForumSystem();

            Forum forum = mainForum.Forums[forumName];
            SubForum subForum = forum.SubForums[subForumName];
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

        public void createThread()
        {
            ForumSystem forumSystem = ForumSystem.initForumSystem();

            Console.WriteLine("Select a forum to view:");
            forumSystem.displayForums();
            string forumName = Console.ReadLine();
            Console.WriteLine("Select a sub-forum to view");
            //viewSubForums(forum, forumSystem);
            string subForumName = Console.ReadLine();
            Console.WriteLine("Enter Thread Title:");
            string threadTitle = Console.ReadLine();
            Thread thread = new Thread(threadTitle);
            Console.WriteLine("Enter Message Content:");
            string content = Console.ReadLine();
            Message message = new Message(content, this.ID);
            thread.Messages.Add(message);

            Forum forum = forumSystem.Forums[forumName];
            SubForum subForum = forum.SubForums[subForumName];
            subForum.Threads.Add(thread.ID, thread);

        }

        public Forum enterForum(string forumName)
        {
            ForumSystem forumSystem = ForumSystem.initForumSystem();
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

        public void postReply(string username)
        {
            ForumSystem forumSystem = ForumSystem.initForumSystem();
            Console.WriteLine("Select a forum to view:");
            forumSystem.displayForums();
            string forumName = Console.ReadLine();
            Console.WriteLine("Select a sub-forum to view:");
            //DisplaySubForums(forum, forumSystem);
            string subForumName = Console.ReadLine();
            Console.WriteLine("Select a Discussion ID:");
            viewDiscussions(subForumName, forumName);
            string discussionId = Console.ReadLine();
            Console.WriteLine("Select a message ID to reply to:");
            viewMessages(discussionId, subForumName, forumName);
            int messageId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Message Content:");
            string content = Console.ReadLine();
            Message message = new Message(content, ID);

            Forum forum = forumSystem.Forums[forumName];
            SubForum subForum = forum.SubForums[subForumName];
            Thread thread = subForum.Threads[discussionId];
            foreach (Message threadMessage in thread.Messages)
            {
                if (messageId.Equals(threadMessage.ID))
                {
                    threadMessage.Replies.Add(message);
                }
            }
        }
    }
}
