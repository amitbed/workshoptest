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
        public Forum(int id, string title, List<int> admins)
        {
            this.id = id;
            this.subForums = new List<SubForum>();
            this.title = title;
            this.admins = admins;
        }

        //Member Variables
        private int id;
        private string title;
        private List<SubForum> subForums;
        private List<int> admins;

        //Methods

        //Gets the forum's title
        public string getTitle()
        {
            return title;
        }

        //This method displays a forum's sub forums
        public void displaySubforums()
        {
            foreach (SubForum subForum in subForums)
            {
                Console.WriteLine(subForum.getTitle());
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
