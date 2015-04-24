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
            if (String.IsNullOrEmpty(title))
            {
                Logger.logError("Failed to create a new thread. Reason: title is empty");
            }
            else
            {
                this.id = IdGen.generateThreadId();
                this.title = title;
                this.messages = new List<Message>();
                Logger.logDebug(String.Format("A new thread has been created. ID: {0}, title: {1}",this.id,this.title));
            }
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

        public bool removeMessage(string memberID, string messageID)
        {
            if ((String.IsNullOrEmpty(memberID)) || (String.IsNullOrEmpty(messageID)))
            {
                if ((String.IsNullOrEmpty(memberID)))
                {
                    Logger.logError("Failed to remove a message. Reason: member id is empty");
                }
                if ((String.IsNullOrEmpty(messageID)))
                {
                    Logger.logError("Failed to remove a message. Reason: message id is empty");
                }
                return false;
            }
            else
            {
                foreach (Message m in messages)
                {
                    if ((m.Equals(messageID)) && (m.UserID.Equals(messageID)))
                    {
                        this.messages.Remove(m);
                        Logger.logDebug(String.Format("Message has been removed. ID:{0}",m.ID));
                        return true;
                    }
                }
                Logger.logError("Failed to remove a message. Reason: message id not found");
                return false;
            }
        }
    }
}
