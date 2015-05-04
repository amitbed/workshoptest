using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ForumSystem;
namespace ForumDB1
{
    class ForumDBContext : DbContext
    {
        //This class interact with the DB behind the scenes
        public virtual DbSet<Forum> Forums { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<SubForum> SubForums { get; set; }
        public virtual DbSet<Thread> Threads { get; set; }
    }

}
