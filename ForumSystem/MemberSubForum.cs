using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem
{
    public class MemberSubForum : SubForum
    {
        public MemberSubForum() { }
        public MemberSubForum(string title, List<string> moderators, string parent, int maxModerators)
            : base(title, moderators, parent, maxModerators)
        {

        }

        //This method creates a new thread with openning message
        public void createThread(Message msg ,string threadToAddName)
        {
            if (threadToAddName!=string.Empty && threadToAddName!=null)
            {
                Thread threadToAdd = Threads[threadToAddName];
                if (threadToAdd != null)
                {
                    threadToAdd.Messages.Add(msg);
                    Threads.Add(threadToAdd.Title, threadToAdd);
                    Logger.logDebug(string.Format("The new thread: {0} has been created successfully with id {1}", threadToAdd.Title, threadToAdd.ID));
                }
            }
            else
            {
                Logger.logError("Failed to add thread. Reason: thread is null");
            }
        }

        public void addMessage(Message msg, string relatedThreadName)
        {
            Thread currThread = Threads[relatedThreadName];
            if (currThread != null)
            {
                currThread.Messages.Add(msg);
            }
        }

        public void fileComplaint(string moderatorUsername, string memberUsername)
        {
            //TODO: add implementation
        }
    }
}
