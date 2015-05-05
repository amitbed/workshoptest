using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem
{
    interface IGuestManager
    {
        void register(string username, string password, string email);
        void login(string username, string password);
    }
}
