using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumSystem;

namespace ForumDB1
{
    class ForumSystemRepository
    {
        //This class contains methods that ask from the ForumDBContext to get data from the DB
        public List<Forum> getForums()
        {
            ForumDBContext fdbc = new ForumDBContext();
            return fdbc.Forums.ToList();
        }
    }
}
