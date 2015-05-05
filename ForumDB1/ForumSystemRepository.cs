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
        //This class contains methods that ask from the ForumDBContext to get data from the DB
        public List<Forum> getForums()
        {
            ForumDBContext fdbc = new ForumDBContext();
            return fdbc.Forums.ToList();
        }

        public List<Member> getMembers()
        {
            var context = new ForumDBContext();
            var query = from member in context.Members select member;
            var members = query.ToList();
            return members;
        }
    }
}
