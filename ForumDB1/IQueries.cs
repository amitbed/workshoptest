using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumSystem;

namespace ForumDB1
{
    interface IQueries
    {
       
        //Forums
        Dictionary<string, Forum> dbGetForums();
        void dbAddForum(Forum forum);
        void dbRemoveForum(string forumID);

        //Sub forums
        Dictionary<string, SubForum> dbGetSubForum();
        void dbAddSubForum(SubForum subForum);
        void dbRemoveSubForum(string subForumID); 

        //Threads
        Dictionary<string, Thread> dbGetThreads();
        void dbAddThread(Thread thread);
        void dbRemoveThread(string ThreadID); 

        //Messages
        Dictionary<string, Message> dbGetMessages();
        void dbAddMessage(Message message);
        void dbRemoveMessage(string messageID);

        //Members
        Dictionary<string, Member> dbGetMembers();              //This query retrieves all members from the DB
        void dbAddMember(Member member);        //This query adds a new member to the DB
        void dbRemoveMember(string MemberID);     //This query removes a member from the DB
        
    }
}
