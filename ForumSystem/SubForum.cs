using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem
{
    public class SubForum
    {
        #region variables
        public string ID { get; set; }
        public string Title { get; set; }
        public List<Thread> Threads { get; set; }
        public List<string> Moderators { get; set; }
        private List<Member> members;

        #endregion

        public SubForum() { }
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
                this.ID = IdGen.generateSubForumId();
                this.Threads = new List<Thread>();
                this.Title = title;
                this.Moderators = moderators;
                this.members = new List<Member>();
                Logger.logDebug(String.Format("A new sub-forum has been created. ID: {0}, title: {1}", this.ID,this.Title));
            }
        }


        //Methods

        //This method displays a sub-forum's threads
        public string displayThreads()
        {               
            StringBuilder sb = new StringBuilder();
            foreach (Thread thread in Threads)
            {
                sb.Append(thread.ID + ". " + thread.Title + "\n");
            }
            return sb.ToString();
        }
    }
}
