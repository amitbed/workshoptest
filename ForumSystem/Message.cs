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
                this.ID = IdGen.generateMessageId();
                this.Content = content;
                this.Date = DateTime.Now;
                this.UserID = userId;
                this.Replies = new List<Message>();
            }
        }
        //Member Variables
        public string ID { get; set; }
        public string Content { get; set; }
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
    }
}
