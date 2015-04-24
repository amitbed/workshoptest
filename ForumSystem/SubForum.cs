using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem
{
    public class SubForum
    {
        //Overload Constructor
        public SubForum(string title, List<string> moderators, string parent)
        {
            if ((String.IsNullOrEmpty(title)) || (String.IsNullOrEmpty(parent)) || (moderators == null))
            {
                if (String.IsNullOrEmpty(title))
                {
                    Logger.logError("Failed to create a new sub-forum. Reason: title is empty");
                }

                if (String.IsNullOrEmpty(parent))
                {
                    Logger.logError("Failed to create a new sub-forum. Reason: parent is empty");
                }
                if (moderators == null)
                {
                    Logger.logError("Failed to create a new sub-forum. Reason: moderators is null");
                }
            }
            else
            {
                this.id = IdGen.generateSubForumId();
                this.threads = new List<Thread>();
                this.title = title;
                this.moderators = moderators;
                this.members = new List<Member>();
                Logger.logDebug(String.Format("A new sub-forum has been created. ID: {0}, title: {1}", this.id,this.title));
            }
        }

        //Member Variables
        private string id;
        private string title;
        private List<Thread> threads;
        private List<string> moderators;
        private List<Member> members;

        //Methods
        //This method returns the thread title
        public string Title
        {
            get { return this.title; }
        }

        //This method returns all threads in the subForum
        public List<Thread> getThreads()
        {
            return threads;
        }

        //This method displays a sub-forum's threads
        public void displayThreads()
        {
            foreach (Thread thread in threads)
            {
                Console.WriteLine(thread.ID + ". " + thread.getTitle());
            }
        }

        public string ID
        {
            get { return this.id; }
        }
    }
}
