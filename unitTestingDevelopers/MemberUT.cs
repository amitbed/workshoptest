using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ForumSystem;
namespace unitTestingDevelopers
{
    [TestClass]
    public class MemberUT
    {
        ForumSystem.ForumSystem system = ForumSystem.ForumSystem.initForumSystem();
        [TestMethod]
        public void checkMember1()
        {
            Member CheckingMember = system.addMember("ifateli","gilAd","ifateli@bgu.ac.il");
            Assert.IsTrue(system.Members.ContainsKey("ifateli"));
        }

        [TestMethod]
        public void checkMember2()
        {
            Member CheckingMember = system.addMember("ifateli", "gilAd", "ifateli@bgu.ac.il");
            Assert.IsTrue(system.Members.ContainsValue(CheckingMember));
        }

        [TestMethod]
        public void checkMember3()
        {
            Member CheckingMember = system.addMember("ifateli", "gilAd", "ifateli@bgu.ac.il");
            Assert.IsFalse(system.Members.ContainsKey("checking"));  
        }

        [TestMethod]
        public void checkMember4()
        {
            Member CheckingMember = system.addMember("ifateli", "gilAd", "ifateli@bgu.ac.il");
            Member BadChecking = new Member("aaa", "bbb", "ccc");
            Assert.IsFalse(system.Members.ContainsValue(BadChecking));
        }
    }
}
