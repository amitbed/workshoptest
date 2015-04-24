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
        public Message(string content, string userId)
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
                this.id = IdGen.generateMessageId();
                this.content = content;
                this.date = DateTime.Now;
                this.userId = userId;
                this.replies = new List<Message>();
            }
        }
        //Member Variables
        private string id;
        //private int topicId;
        private string content;
        private DateTime date;
        private string userId;
        private List<Message> replies;

        //Methods
        //This method returns a message content
        public string UserID
        {
            get { return this.userId; }
        }

        public string getContent()
        {
            return content;
        }

        //This method returns the message id
        public string ID
        {
            get { return id; }
        }

        //This method returns the message date
        public DateTime getDate()
        {
            return date;
        }

        //This method displays the message
        public void displayMessage()
        {
            Console.WriteLine("Message Id: " + this.id);
            Console.WriteLine(date);
            Console.WriteLine(content);
        }

        public List<Message> getReplies()
        {
            return replies;
        }
    }
}
