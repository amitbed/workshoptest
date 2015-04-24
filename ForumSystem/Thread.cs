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
            this.id = IdGen.generateThreadId();
            this.title = title;
            this.messages = new List<Message>();
        }

        //Member Variables
        private string id;
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

        public string ID
        {
            get { return this.id; }
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
