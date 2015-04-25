using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ForumSystem;

namespace ForumTests
{
    [TestClass]
    public class ProjectTest
    {
        private BridgeProject bridge = Driver.getBridge();
        protected ForumSystem.ForumSystem system = ForumSystem.ForumSystem.initForumSystem();

        //List<UserInfo> membersList;


        //recipesForPassover = createSubForum(11, null, "recipesForPassover", new List<long>(20566));
        //readonly SubForum

        public virtual void SetUp()
        {
            //this.bridge = Driver.getBridge();
            setUpMembers();
            setUpForum();
        }

        private void setUpMembers()
        {
            Member Sagi = bridge.createMember("sagiav", "maihayafa", "sagiav@post.bgu.ac.il"); //30548, "sagiav", "sagiav@post.bgu.ac.il", "gold", "maihyafa", true, null, null, null, null);
            Member Amit = bridge.createMember("amitbed", "ronahayafa","amitbed@post.bgu.ac.il");
            Member Dean = bridge.createMember("abadie", "liatush", "abadie.post@post.bgu.ac.il");
        }

        private void setUpForum()
        {
            List<string> adminDating = new List<string>();
            adminDating.Add("sagiav");
            List<string> adminFood = new List<string>();
            adminFood.Add("amitbed");
            Forum Dating = bridge.createForum("Dating", adminDating);
            Forum Food = bridge.createForum("Food", adminFood);
        }

        public Forum createForum(string title, List<string> admins)
        {
            return bridge.createForum(title, admins);
        }

        public Forum searchForum(string forumName)
        {
            return system.searchForum(forumName);
        }

        public SubForum setUpSubForum(string title, List<string> moderators, string parent)
        {
            return bridge.createSubForum(title, moderators, parent);
        }

        public bool subForumInForum(List<SubForum> subForums, Forum forum)
        {
            bool ans = true;
            Dictionary<string, SubForum> listToCheck = forum.SubForums;
            foreach (SubForum sub in subForums)
            {
                if (!listToCheck.ContainsKey(sub.Title)) //Contains(sub))
                ans = false;
            }

            return ans;
        }

        public bool isGuestRegistered(string guestName)
        {
            bool ans = false;
            foreach (Member m in system.Members)
            {
                if (m.Username == guestName)
                {
                    ans = true;
                }
            }
            return ans;
        }
        public void Register(Guest g, string username, string password, string email)
        {
            bridge.register(g, username, password, email);
        }

        public void removeSubForum(string sfName, string forumName)
        {
            bridge.removeSubForum(sfName, forumName);
        }
    }
}
