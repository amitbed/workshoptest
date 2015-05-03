using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem
{
    public class Message
    {
        //Overload Contructor
        public Message(string title, string content, string userId)
        {
            if ((String.IsNullOrEmpty(content)) || (String.IsNullOrEmpty(userId)))
            {
                if (String.IsNullOrEmpty(content))
                {
                    Logger.logError("Failed to create a new message. Reason: content is empty");
                }

                if (String.IsNullOrEmpty(userId))
                {
                    Logger.logError("Failed to create a new message. Reason: ID is empty");
                }
            }
            else
            {
                this.ID = IdGen.generateMessageId();
                this.Title = title;
                this.Content = content;
                this.Date = DateTime.Now;
                this.UserID = userId;
                this.Replies = new List<Message>();
            }
        }
        //Member Variables
        public string ID { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string UserID { get; set; }
        public List<Message> Replies { get; set; }

        //Methods

        //This method displays the message
        public string displayMessage()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Message Id: " + this.ID);
            sb.Append("Message Date: " + Date);
            sb.Append("Message Content: " + Content + "\n");
            return sb.ToString();
        }

        public void postReply(Message reply, string replierID)
        {

            if (reply != null)
            {
                Replies.Add(reply);
                Logger.logDebug(string.Format("The new reply: {0} has been created successfully with id {1}", reply.Title, reply.ID));
            }
            else
            {
                Logger.logError("Failed to add reply. Reason: reply is null");
            }
            
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
        }
    }
}
