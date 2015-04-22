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
        public Message(int topicId, string content, string userId)
        {
            Random rnd = new Random();
            this.id = rnd.Next(2000, 20000);
            this.topicId = topicId;
            this.content = content;
            this.date = DateTime.Now;
            this.userId = userId;
            this.replies = new List<Message>();
        }
        //Member Variables
        private int id;
        private int topicId;
        private string content;
        private DateTime date;
        private string userId;
        private List<Message> replies;

        //Methods
        //This method returns a message content
        public string getContent()
        {
            return content;
        }

        //This method returns the message id
        public int getMessageId()
        {
            return id;
        }

        //This method returns the message date
        public DateTime getDate()
        {
            return date;
        }

        //This method displays the message
        public void displayMessage()
        {
            Console.WriteLine("Message Id: " + getMessageId());
            Console.WriteLine(date);
            Console.WriteLine(content);
        }

        public List<Message> getReplies()
        {
            return replies;
        }
    }
}
