using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumDB
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ForumDBContext())
            {
                var forum = new Forum { ForumID = 1, Title = "Test forum" };
                db.Forums.Add(forum);
                db.SaveChanges();
            }
        }
    }
}
