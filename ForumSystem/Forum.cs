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
            if ((admins == null) || (String.IsNullOrEmpty(title)))
            {
                if ((String.IsNullOrEmpty(title)) && (!(admins == null)))
                {
                    Logger.logError(string.Format("Failed to create a new forum. Reason: title is empty"));
                }
                if ((!String.IsNullOrEmpty(title)) && ((admins == null)))
                {
                    Logger.logError(string.Format("Failed to create a new forum. Reason: admins is null"));
                }
            }
            else
            {
                Logger.logDebug(string.Format("The new forum: {0} has been created successfully with id {1}", title, id));
            }
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
            if (subForum != null)
            {
                subForums.Add(subForum);
                Logger.logDebug(string.Format("The new sub forum: {0} has been created successfully with id {1}", subForum.Title, subForum.ID));
            }
            else
            {
                Logger.logError("Failed to add sub forum. Reason: sub forum is null");
            }

        }

        public string ID
        {
            get { return this.id; }
        }

        public SubForum SearchSubForum(string sfName)
        {
            foreach (SubForum sf in subForums)
            {
                if (sf.Title.Equals(sfName))
                {
                    return sf;
                }
            }
            return null;
        }
    }
}
