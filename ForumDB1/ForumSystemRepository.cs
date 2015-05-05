using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumSystem;

namespace ForumDB1
{
    class ForumSystemRepository : IQueries
    {
        public ForumDBContext initDB()
        {
            return new ForumDBContext();
        }

        
        //This class contains methods that ask from the ForumDBContext to get data from the DB
        public List<Forum> getForums()
        {
            ForumDBContext fdbc = new ForumDBContext();
            return fdbc.Forums.ToList();
        }


        //Members
        public List<Member> dbGetMembers()
        {
            var context = new ForumDBContext();
            var query = from member in context.Members select member;
            var members = query.ToList();
            return members;
        }

        public void dbAddMember(Member member)
        {
            var context = new ForumDBContext();
            context.Members.Add(member);
            context.SaveChanges();
        }

        public void dbRemoveMember(string memberID)
        {
            var context = new ForumDBContext();
            var member = (from m in context.Members
                        where m.ID == memberID
                        select m).FirstOrDefault();
            context.Members.Remove(member);
            context.SaveChanges();
        }
    }
}
