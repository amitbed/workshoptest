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
        ForumSystem.ForumSystem system;

        public override void SetUp()
        {
            base.SetUp();
            setUpForum();
        }

        private void setUpForum()
        {
            system = ForumSystem.ForumSystem.getInstance();
            Dating = getForum(0);
            Food = getForum(1);
        }

        [TestMethod]
        public void initForumTest()
        {
            SetUp();
            Assert.IsNotNull(system);
        }


        [TestMethod]
        public void AddNewSubForumTest()
        {
            List<SubForum> FoodSubs = new List<SubForum>();
            SubForum PassoverRecepies = setUpSubForum(11, "PassoverRecepies", null, "Food");
            SubForum ChosherRecepies = setUpSubForum(12, "ChosherRecepies", null, "Food");
            FoodSubs.Add(PassoverRecepies);
            FoodSubs.Add(ChosherRecepies);
            Assert.IsTrue(subForumInForum(FoodSubs, Food));
        }

        [TestMethod]
        public void removeSubForum()
        {

        }
    }
}
