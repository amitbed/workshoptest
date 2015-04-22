using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem
{
    public class Thread
    {
        //Overload Constructor
        public Thread(string title)
        {
            Random rnd = new Random();
            this.id = rnd.Next(1, 1000);
            this.title = title;
            this.messages = new List<Message>();
        }

        //Member Variables
        private int id;
        private string title;
        private List<Message> messages;

        //Methods
        public string getTitle()
        {
            return title;
        }

        public List<Message> getMessages()
        {
            return messages;
        }

        public int getTopicId()
        {
            return id;
        }

        public void displayMessages()
        {
            foreach (Message message in messages)
            {
                message.displayMessage();
            }
        }
    }
}
