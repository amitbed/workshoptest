using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem
{
    public class Forum
    {
        //Overload Constructor
        public Forum(string title, List<string> admins)
        {
            this.id = IdGen.generateForumId();
            this.subForums = new List<SubForum>();
            this.title = title;
            this.admins = admins;
        }

        //Member Variables
        private string id;
        private string title;
        private List<SubForum> subForums;
        private List<string> admins;

        //Methods

        //Gets the forum's title
        public string Title
        {
            get { return this.title; }
        }

        //This method displays a forum's sub forums
        public void displaySubforums()
        {
            foreach (SubForum subForum in subForums)
            {
                Console.WriteLine(subForum.Title);
            }
        }

        //This method returns a forum's sub-forums
        public List<SubForum> getSubForums()
        {
            return subForums;
        }

        //This method adds a sub-forum to the current forum
        public void addSubForum(SubForum subForum)
        {
            subForums.Add(subForum);
        }
    }
}
