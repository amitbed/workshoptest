using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem
{
    class IdGen
    {
        private static long member=0;
        private static long forum=0;
        private static long thread=0;
        private static long subForum = 0;
        private static long message = 0;

        public IdGen()
        {

        }

        public static string generateMessageId()
        {
            IdGen.message++;
            return ("message" + IdGen.message);
        }

        public static string generateMemberId(){
            IdGen.member++;
            return ("member" + IdGen.member);
        }

        public static string generateForumId()
        {
            IdGen.forum++;
            return ("forum" + IdGen.forum);
        }

        public static string generateThreadId()
        {
            IdGen.thread++;
            return ("thread" + IdGen.thread);
        }

        public static string generateSubForumId()
        {
            IdGen.subForum++;
            return ("subforum" + IdGen.subForum++);
        }
    }
}
