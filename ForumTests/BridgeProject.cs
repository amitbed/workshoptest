using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumSystem;
namespace ForumTests
{
    interface BridgeProject
    {
        void addNewaddNewForum(ForumSystem.Forum Forum);
        Forum createForum(string title, List<string> admins);
        SubForum createSubForum(string title, List<string> moderators, string parent);
        Member createMember(string username, string password, string email);
        void register(Guest g, string username, string password, string email);
        void removeSubForum(string sfName, string forumName);
        bool IsSubForumExists(string subForumName, string forumName);
        string login(Guest g,string id, string username, string password);
        //void addMemberToSystem(Member member);
    }
}


////Member Interface
//virtual public string getContent();
//virtual public int getMessageId();
//virtual public DateTime getDate();
//virtual public void displayMessage();
//virtual public List<Message> getReplies();

////SubForum Interface
//virtual public string getTitle();
//virtual public List<Thread> getThreads();
//virtual public void displayThreads();
//virtual public void displayMessages();

////Forum Interface
//virtual public string getTitle();
//virtual public void displaySubForums();
//virtual public List<SubForum> getSubForums();
//virtual public void addSubForum(SubForum subforum);

////ForumSystem Interface
//virtual public ForumSystem.ForumSystem getInstance();
//virtual public void addForum(Forum forum);
//virtual public void displayForums();
//virtual public List<Forum> getForums();
