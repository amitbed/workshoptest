using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ForumSystem;
using System.Collections.Generic;

namespace ForumTests
{
    [TestClass]
    public class TestForum : ProjectTest
    {
        private Forum Dating, Food;

        public override void SetUp()
        {
            base.SetUp();
            setUpForum();
        }

        private void setUpForum()
        {
            Dating = searchForum("Dating");
            Food = searchForum("Food");
        }

        //UC1 - init Forum
        [TestMethod]
        public void initForumTest()
        {
            SetUp();
            Assert.IsNotNull(system);
        }

        //UC2 - Create Forum
        [TestMethod]
        public void twoInitForumsAddedTest()
        {
            Assert.AreEqual<int>(2, system.Forums.Count);
        }

        [TestMethod]
        public void addForumTest()
        {
            int prevNumOfForums = system.Forums.Count;
            List<string> adminSport = new List<string>();
            adminSport.Add(base.Dean.ID);
            Forum Sport = createForum("Sport", adminSport);
            int newNumOfForums = system.Forums.Count;

            Assert.AreEqual<int>(newNumOfForums, prevNumOfForums + 1);
        }

       //UC6 - register
        [TestMethod]
        public void registerTest()
        {
            Guest Nofar = new Guest();
            Register(Nofar, "benshnof", "matanShoham", "benshnof@post.bgu.ac.il");
            Assert.IsTrue(isGuestRegistered("benshnof"));
        }

        [TestMethod]
        public void registerFalseTest()
        {
            Guest Nofar = new Guest();
            Register(Nofar, "benshnof", "matanShoham", "benshnof@post.bgu.ac.il");
            Assert.IsFalse(isGuestRegistered("nofar"));
        }

        //[TestMethod]
        //public void loginTest()
        //{
        //    Member Sagi = searchMember("sagiav");
        //    login(Sagi);
        //}


        //UC7 - Create SubForum
        [TestMethod]
        public void AddNewSubForumTest()
        {
            List<string> moderators = new List<string>();
            moderators.Add(base.Sagi.ID);
            List<SubForum> FoodSubs = new List<SubForum>();
            SubForum PassoverRecepies = setUpSubForum("PassoverRecepies", moderators, "Food");
            SubForum ChosherRecepies = setUpSubForum("ChosherRecepies", moderators, "Food");
            FoodSubs.Add(PassoverRecepies);
            FoodSubs.Add(ChosherRecepies);
            Assert.IsTrue(subForumInForum(FoodSubs, system.searchForum("Food")));
        }

        [TestMethod]
        public void AddNewSubForumWithWrongForumNameTest()
        {
            List<string> moderators = new List<string>();
            moderators.Add(base.Sagi.ID);
            List<SubForum> FoodSubs = new List<SubForum>();
            SubForum PassoverRecepies = setUpSubForum("PassoverRecepies", moderators, "Ochel");
            FoodSubs.Add(PassoverRecepies);
            Forum f = system.searchForum("Food");
            Assert.IsFalse(subForumInForum(FoodSubs, f));
        }

        [TestMethod]
        public void SubForumAddedOnlyToNeededForumTest()
        {
            List<string> moderators = new List<string>();
            moderators.Add("sagiav");
            List<SubForum> FoodSubs = new List<SubForum>();
            SubForum PassoverRecepies = setUpSubForum("PassoverRecepies", moderators, "Food");
            FoodSubs.Add(PassoverRecepies);
            Forum f =  system.searchForum("Dating");
            Assert.IsFalse(subForumInForum(FoodSubs,f));
        }

        [TestMethod]
        public void nonAdminAddSubForumTest()
        {
            Guest NofarGuest = new Guest();
            Member Nofar = CreateMember("benshnof", "matanShoham", "benshnof@post.bgu.ac.il");
            Forum currForum = Nofar.enterForum("Food");
            List<string> moderators = new List<string>();
            moderators.Add(Nofar.ID);
            SubForum ShavuotRecepies = setUpSubForum("ShavuotRecepies", moderators, "Food");
            currForum.addSubForum(ShavuotRecepies);
            Assert.IsTrue(IsSubForumExists("ShavuotRecepies", "Food"));
        }

        [TestMethod]
        public void loginTest()
        {
            Guest NofarGuest = new Guest();
            Member Nofar = CreateMember("benshnof", "matanShoham", "benshnof@post.bgu.ac.il");
            String forumList = login(NofarGuest,Nofar.ID, "benshnof", "matanShoham");
            String realForumList=system.displayForums();
            Assert.IsTrue(String.Equals(forumList,realForumList));
        }

        [TestMethod]
        public void loginFalseTest()
        {
            Guest NofarGuest = new Guest();
            String forumList = login(NofarGuest, "", "benshnof", "matanShoham");
            String realForumList = system.displayForums();
            Assert.IsFalse(String.Equals(forumList, realForumList));
        }
    }
}
