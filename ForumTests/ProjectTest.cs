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
        List<Member> testMembers = new List<Member>();
        protected Member Sagi;
        protected Member Amit;
        protected Member Dean;
        public virtual void SetUp()
        {
            setUpMembers();
            setUpForum();
        }

        private void setUpMembers()
        {
            Sagi = bridge.createMember("sagiav", "maihayafa", "sagiav@post.bgu.ac.il");
            Amit = bridge.createMember("amitbed", "ronahayafa","amitbed@post.bgu.ac.il");
            Dean = bridge.createMember("abadie", "liatush", "abadie.post@post.bgu.ac.il");
            testMembers.Add(Sagi);
            testMembers.Add(Amit);
            testMembers.Add(Dean);
        }

        private void setUpForum()
        {
            List<string> adminDating = new List<string>();
            adminDating.Add(Sagi.ID);
            List<string> adminFood = new List<string>();
            adminFood.Add(Amit.ID);
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
        /*
        public SubForum setUpSubForum(string title, List<string> moderators, string parent, int maxModerators)
        {
            return bridge.createSubForum(title, moderators, parent, maxModerators);
        }
        */
        public void Register(Guest g, string username, string password, string email)
        {
            bridge.register(g, username, password, email);
        }

        public void removeSubForum(string sfName, string forumName)
        {
            bridge.removeSubForum(sfName, forumName);
        }

        public string login(Guest g,string id, string username, string password)
        {
           return bridge.login(g,id, username, password);
        }

        public Member CreateMember(string username, string password, string email)
        {
            return bridge.createMember(username, password, email);
        }

        public void addMemberToSystem(Member member)
        {
            bridge.addMemberToSystem(member);
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

        public bool IsSubForumExists(string subForumName, string forumName)
        {
            return IsSubForumExists(subForumName, forumName);
        }

        public bool isGuestRegistered(string guestName)
        {
            bool ans = false;
            foreach (Member m in system.Members.Values)
            {
                if (m.Username == guestName)
                {
                    ans = true;
                }
            }
            return ans;
        }

        public Member getMember(string memberUsername)
        {
            return bridge.getMember(memberUsername);
        }
    }
}
