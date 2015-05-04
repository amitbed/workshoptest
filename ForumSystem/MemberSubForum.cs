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
                    threadToAdd.Messages.Add(msg.Title, msg);
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
            ForumSystem forumSystem = ForumSystem.initForumSystem();
            string username = msg.UserName;
            Member currMember = forumSystem.Members[username];
            if (currMember != null)
            {
                Logger.logDebug(string.Format("Member: {0} increase number of published messages", username));
                currMember.numOfPublishedMessages++;
            }
            Thread currThread = Threads[relatedThreadName];
            if (currThread != null)
            {
                currThread.Messages.Add(msg.Title, msg);
                Logger.logDebug(string.Format("Message: {0} has added to thread", msg.Title));
            }
        }

        public void addReply(Message msgReply, string ParentMsgTopic, string threadName)
        {
            ForumSystem forumSystem = ForumSystem.initForumSystem();
            string username = msgReply.UserName;
            Member currMember = forumSystem.Members[username];
            if (currMember != null)
            {
                Logger.logDebug(string.Format("Member: {0} increase number of published messages", username));
                currMember.numOfPublishedMessages++;
            }
         
            Thread currThread = Threads[threadName];
            if (currThread != null)
            {
                currThread.Messages[ParentMsgTopic].Replies.Add(msgReply);
                Logger.logDebug(string.Format("Message: {0} has added as reply to msg {1}", msgReply.Title, ParentMsgTopic));
            }
        }
        public void fileComplaint(string moderatorUsername, string memberUsername)
        {
            //TODO: add implementation
        }

        public void removeMessage(string memberUsername, string threadName, string messageTopic)
        {
            if (Threads.ContainsKey(threadName)){
                Thread currThread = Threads[threadName];
                if (currThread.Messages.ContainsKey(messageTopic))
                {
                    Message currMessage = currThread.Messages[messageTopic];

                    if (memberUsername.Equals(currMessage.UserName))
                    {
                        currMessage.delete();
                        currThread.Messages.Remove(messageTopic);
                        Logger.logDebug(string.Format("Message: {0} was succesfully removed", messageTopic));
                    }
                }
                else
                {
                    Logger.logError(string.Format("Msg: {0} does not exist", messageTopic));
                }
            }
            Logger.logError(string.Format("Thread: {0} does not exist", threadName));
        }
    }
}
