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
        List<Forum> getForums();                //This query retrieves all forums from the DB
        //void addForum(string forumID);          //This query adds a new forum to the DB
        //void removeForum(string forumID);       //This query removes a forum from the DB
        //void updateForum(string forumID);       //This query updates a forum from the DB

        List<Member> getMembers();              //This query retrieves all members from the DB
        //void addMember(string memberID);        //This query adds a new member to the DB
        //void removeMember(string MemberID);     //This query removes a member from the DB
        //void updateMember(string MemberID);     //This query updates a member from the DB
    }
}
