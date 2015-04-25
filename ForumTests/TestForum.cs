﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ForumSystem;
using System.Collections.Generic;

namespace ForumTests
{
    [TestClass]
    public class TestForum : ProjectTest
    {
        private Forum Dating, Food;
        //ForumSystem.ForumSystem system;

        public override void SetUp()
        {
            base.SetUp();
            setUpForum();
        }

        private void setUpForum()
        {
            //system = ForumSystem.ForumSystem.initForumSystem();
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
            adminSport.Add("abadie");
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
            moderators.Add("sagiav");
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
            moderators.Add("sagiav");
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


        //[TestMethod]
        //public void removeSubForum()
        //{
        //    removeSubForum("PassoverRecepies", "Food");

        //}
    }
}
