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
            this.id = IdGen.generateSubForumId();
            this.threads = new List<Thread>();
            this.title = title;
            this.moderators = moderators;
            this.members = new List<Member>();
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
    }
}
