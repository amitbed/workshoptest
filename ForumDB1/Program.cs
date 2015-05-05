using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumSystem;

namespace ForumDB1
{
    class Program
    {
        static void Main(string[] args)
        {
          /*  using (var db = new ForumDBContext())
            {
                var mem = new Member("Amit", "123456789", "amit@abc.com");
            //    var mem = new Member { Username = "Amit", Password = "123456789", Email = "amit@abc.com" };
                db.Members.Add(mem);
                db.SaveChanges();
            }*/
            ForumSystemRepository repository = new ForumSystemRepository();
            Member member = new Member("Shimon", "123456789", "li@gmail.com");
            
        }
    }
}
